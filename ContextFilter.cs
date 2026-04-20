using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveFund
{
    public static class ContextFilter
    {
        private static DataGridView? _grid;
        private static Dictionary<int, object> _activeFilters = new Dictionary<int, object>();
        private static ToolStripMenuItem? _parentMenuItem;
        public static void ResetFilter(DataGridView grid, ToolStripMenuItem parentMenuItem)
        {
            _activeFilters = new Dictionary<int, object>();
            CreateFilterContextMenu(grid, parentMenuItem);
        }
        public static void CreateFilterContextMenu(DataGridView grid, ToolStripMenuItem parentMenuItem)
        {
            _grid = grid;
            _parentMenuItem = parentMenuItem;
            parentMenuItem.DropDownItems.Clear();

            // Добавляем пункт "Сбросить все фильтры" в корень меню
            var resetAllItem = new ToolStripMenuItem("Сбросить все фильтры");
            resetAllItem.Click += (s, e) => ClearAllFilters();

            // Подсветка, если есть хоть один активный фильтр
            if (_activeFilters.Count > 0)
                resetAllItem.BackColor = Color.LightCoral;

            parentMenuItem.DropDownItems.Add(resetAllItem);
            parentMenuItem.DropDownItems.Add("-"); // Разделитель

            for (int colIndex = 1; colIndex < grid.Columns.Count; colIndex++)
            {
                var column = grid.Columns[colIndex];
                if (column == null || !column.Visible) continue;

                var uniqueValues = GetUniqueColumnValues(grid, colIndex);
                var columnMenu = new ToolStripMenuItem(column.HeaderText);
                if (uniqueValues.Count >= grid.RowCount)
                    columnMenu.Visible = false;
                // Подсветка колонки, если есть активный фильтр
                if (_activeFilters.ContainsKey(colIndex))
                    columnMenu.BackColor = Color.LightGreen;

                parentMenuItem.DropDownItems.Add(columnMenu);

                // Пункт "Все"
                var allItem = new ToolStripMenuItem("Все");
                int capturedColIndex = colIndex;
                allItem.Click += (s, e) => ToggleFilter(capturedColIndex, null);

                if (IsFilterActive(colIndex, null))
                    allItem.BackColor = Color.LightGreen;

                columnMenu.DropDownItems.Add(allItem);
                columnMenu.DropDownItems.Add("-");

                // Пункты для уникальных значений
                foreach (var value in uniqueValues)
                {
                    var display = value?.ToString() ?? "(пусто)";
                    var item = new ToolStripMenuItem(display);
                    int capturedCol = colIndex;
                    object? capturedValue = value;

                    item.Click += (s, e) => ToggleFilter(capturedCol, capturedValue);

                    if (IsFilterActive(colIndex, value))
                        item.BackColor = Color.LightGreen;

                    columnMenu.DropDownItems.Add(item);
                }
                if (parentMenuItem.DropDownItems.Count <= 3)
                    parentMenuItem.Visible = false;
                else parentMenuItem.Visible = true;
            }
        }

        private static bool IsFilterActive(int colIndex, object? value)
        {
            if (_grid == null || colIndex >= _grid.Columns.Count) return false;

            if (value == null)
                return _activeFilters.ContainsKey(colIndex);

            return _activeFilters.ContainsKey(colIndex) && Equals(_activeFilters[colIndex], value);
        }

        private static void ToggleFilter(int colIndex, object? value)
        {
            if (_grid == null) return;

            if (colIndex >= _grid.Columns.Count)
            {
                _activeFilters.Clear();
                return;
            }

            if (value == null)
            {
                _activeFilters.Remove(colIndex);
            }
            else
            {
                if (_activeFilters.ContainsKey(colIndex) && Equals(_activeFilters[colIndex], value))
                    _activeFilters.Remove(colIndex);
                else
                    _activeFilters[colIndex] = value;
            }

            ApplyAllFilters();
            RefreshMenu();
        }

        private static void RefreshMenu()
        {
            if (_parentMenuItem != null && _grid != null)
            {
                CreateFilterContextMenu(_grid, _parentMenuItem);
            }
        }

        private static void ApplyAllFilters()
        {
            if (_grid == null) return;

            // Приостанавливаем привязку
            CurrencyManager? currencyManager = null;
            if (_grid.DataSource != null)
            {
                try
                {
                    currencyManager = (CurrencyManager?)_grid?.BindingContext?[_grid.DataSource];
                    currencyManager?.SuspendBinding();
                }
                catch { }
            }

            var currentCell = _grid?.CurrentCell;
            _grid.CurrentCell = null;

            try
            {
                foreach (DataGridViewRow row in _grid is not null ? _grid.Rows : new DataGridViewRowCollection(new DataGridView()))
                {
                    if (row.IsNewRow) continue;
                    row.Visible = IsRowMatchesFilters(row);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Filter error: {ex.Message}");
                foreach (DataGridViewRow row in _grid is not null ? _grid.Rows : new DataGridViewRowCollection(new DataGridView()))
                {
                    if (!row.IsNewRow) row.Visible = true;
                }
            }
            finally
            {
                try
                {
                    if (currencyManager != null) currencyManager.ResumeBinding();
                }
                catch { }

                // Возвращаем выделение
                try
                {
                    if (currentCell != null && currentCell.RowIndex < _grid?.RowCount &&
                        !_grid.Rows[currentCell.RowIndex].IsNewRow &&
                        _grid.Rows[currentCell.RowIndex].Visible)
                    {
                        _grid.CurrentCell = currentCell;
                    }
                }
                catch { }
            }
        }

        private static bool IsRowMatchesFilters(DataGridViewRow row)
        {
            foreach (var filter in _activeFilters)
            {
                int col = filter.Key;

                if (col >= _grid?.Columns.Count || col < 0 || col >= row.Cells.Count)
                    continue;

                object filterValue = filter.Value;
                object? cellValue = row.Cells[col].Value;

                if (!Equals(cellValue, filterValue))
                    return false;
            }
            return true;
        }

        private static HashSet<object> GetUniqueColumnValues(DataGridView grid, int columnIndex)
        {
            var values = new HashSet<object>();

            if (columnIndex >= grid.Columns.Count) return values;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow && columnIndex < row.Cells.Count)
                    values.Add(row.Cells[columnIndex].Value ?? new object());
            }
            return values;
        }

        public static void ClearAllFilters()
        {
            _activeFilters.Clear();
            if (_grid != null)
            {
                ApplyAllFilters();
                RefreshMenu();
            }
        }

        // Опционально: получение активных фильтров
        public static Dictionary<int, object> GetActiveFilters()
        {
            return new Dictionary<int, object>(_activeFilters);
        }

        // Опционально: проверка, есть ли активные фильтры
        public static bool HasActiveFilters()
        {
            return _activeFilters.Count > 0;
        }
    }
}