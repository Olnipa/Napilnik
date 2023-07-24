using Microsoft.Data.Sqlite;
using System.Data;
using System.Reflection;
using Xceed.Wpf.Toolkit;

namespace CleanCode.MethodRefactoring
{
    //internal class Class1
    //{
    //    private const int _minPassportLenght = 10;
    //    private const int _sqlNotFoundErrorCode = 1;
    //    private const int _dataRawIndex = 1;
    //    private const int _dataRawObjectIndex = 1;

    //    private void OnVoteButtonClick(object sender, EventArgs e)
    //    {
    //        if (_passportTextbox.Text.Trim() == "")
    //        {
    //            int num1 = (int)MessageBox.Show("Введите серию и номер паспорта");
    //        }
    //        else
    //        {
    //            string rawData = _passportTextbox.Text.Trim().Replace(" ", string.Empty);

    //            if (rawData.Length < _minPassportLenght)
    //                _textResult.Text = "Неверный формат серии или номера паспорта";
    //            else
    //                TryOpenAccessToVote(rawData);
    //        }
    //    }

    //    private void TryOpenAccessToVote(string passportRawData)
    //    {
    //        string commandText = string.Format("select * from passports where num='{0}' limit 1;", (object)Form1.ComputeSha256Hash(passportRawData));
    //        string connectionString = string.Format("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");

    //        try
    //        {
    //            DataTable dataTable = GetDateTable(connectionString, commandText);
    //            _textResult.Text = GetAccessibilityToVote(dataTable);
    //        }
    //        catch (SqliteException ex)
    //        {
    //            if (ex.ErrorCode != _sqlNotFoundErrorCode)
    //                return;

    //            int num2 = (int)MessageBox.Show("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
    //        }
    //    }

    //    private DataTable GetDateTable(string connectionString, string commandText)
    //    {
    //        SqliteConnection connection = new SqliteConnection(connectionString);
    //        connection.Open();
    //        SqliteDataAdapter sqLiteDataAdapter = new SqliteDataAdapter(new SqliteCommand(commandText, connection));
    //        DataTable dataTable1 = new DataTable();
    //        DataTable dataTable2 = dataTable1;
    //        sqLiteDataAdapter.Fill(dataTable2);
    //        connection.Close();

    //        return dataTable1;
    //    }

    //    private string GetAccessibilityToVote(DataTable dataTable)
    //    {
    //        if (dataTable.Rows.Count > 0)
    //        {
    //            if (Convert.ToBoolean(dataTable.Rows[_dataRawIndex].ItemArray[_dataRawObjectIndex]))
    //                return "По паспорту «" + _passportTextbox.Text + "» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
    //            else
    //                return "По паспорту «" + _passportTextbox.Text + "» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
    //        }
    //        else
    //        {
    //            return "Паспорт «" + _passportTextbox.Text + "» в списке участников дистанционного голосования НЕ НАЙДЕН";
    //        }
    //    }
    //}
}