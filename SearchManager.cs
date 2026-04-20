using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

public class DynamicSearch
{
    private MySqlConnection connection;
    private DataGridView dataGridView;

    public DynamicSearch(MySqlConnection conn, DataGridView gridView)
    {
        connection = conn;
        dataGridView = gridView;
    }

    /// <summary>
    /// Выполняет динамический поиск по указанным колонкам таблицы
    /// </summary>
    /// <param name="tableName">Имя таблицы для поиска</param>
    /// <param name="searchColumns">Массив колонок для поиска</param>
    /// <param name="searchText">Текст для поиска</param>
    /// <param name="additionalConditions">Дополнительные условия WHERE (опционально)</param>
    public void Search(string tableName, string[] searchColumns, string searchText, string additionalConditions = "")
    {
        if (string.IsNullOrEmpty(searchText))
        {
            // Если текст поиска пустой — показываем все данные
            LoadAllData(tableName);
            return;
        }

        // Формируем условие поиска по всем указанным колонкам
        string searchCondition = string.Join(" OR ",
            searchColumns.Select(col => $"{col} LIKE @search"));

        // Добавляем дополнительные условия, если есть
        if (!string.IsNullOrEmpty(additionalConditions))
        {
            searchCondition += $" AND {additionalConditions}";
        }

        string sqlQuery = $"SELECT * FROM {tableName} WHERE {searchCondition}";

        try
        {
            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
            {
                // Добавляем параметр для безопасного поиска
                cmd.Parameters.AddWithValue("@search", $"%{searchText}%");

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Обновляем DataGridView
                    UpdateDataGridView(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при поиске: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Загружает все данные из таблицы (используется при пустом поиске)
    /// </summary>
    /// <param name="tableName">Имя таблицы</param>
    private void LoadAllData(string tableName)
    {
        try
        {
            string sqlQuery = $"SELECT * FROM {tableName}";

            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                UpdateDataGridView(dataTable);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Обновляет DataGridView новыми данными
    /// </summary>
    /// <param name="dataTable">DataTable с новыми данными</param>
    private void UpdateDataGridView(DataTable dataTable)
    {
        dataGridView.DataSource = null;
        dataGridView.Rows.Clear();
        dataGridView.Columns.Clear();

        // Привязываем данные к DataGridView
        dataGridView.DataSource = dataTable;

        // Автоматически настраиваем колонки
        dataGridView.AutoGenerateColumns = true;

        // Настраиваем внешний вид
        ConfigureDataGridView();
    }

    /// <summary>
    /// Настраивает внешний вид DataGridView
    /// </summary>
    private void ConfigureDataGridView()
    {
        dataGridView.ReadOnly = true;
        dataGridView.AllowUserToAddRows = false;
        dataGridView.AllowUserToDeleteRows = false;
        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView.MultiSelect = false;

        // Автоподбор ширины колонок
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }
}
