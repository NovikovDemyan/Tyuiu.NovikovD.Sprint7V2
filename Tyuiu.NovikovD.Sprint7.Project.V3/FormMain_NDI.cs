using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.NovikovD.Sprint7.Project.V3;
using Tyuiu.NovikovD.Sprint7.Project.V3.Lib;

namespace Tyuiu.NovikovD.Sprint7.Project.V3
{
    public partial class FormMain_NDI : Form
    {
        public FormMain_NDI()
        {
            InitializeComponent();
            dataGridViewInfo_NDI.RowCount = 100;
            dataGridViewInfo_NDI.ColumnCount = 100;
            for (int i = 0; i < 100; i++)
            {
                dataGridViewInfo_NDI.Columns[i].Width = 130;
            }
            dataGridViewInfo_NDI.Columns[2].Width = 180;
        }
        DataService ds = new DataService();
        public static string path = $@"{Directory.GetCurrentDirectory()}\Project\Университет.csv";

        private void buttonSaveFile_NDI_Click(object sender, EventArgs e)
        {
            if ((textBoxFIO_NDI.Text == "") || (textBoxAddEntrance_NDI.Text == "") || (textBoxFlatArea_NDI.Text == "") || (textBoxAddFlat_NDI.Text == "") || (textBoxSumPeople_NDI.Text == "") || (textBoxSumRoom_NDI.Text == "") || ((radioButtonBuy_NDI.Checked == false) && (radioButtonRent_NDI.Checked == false)))
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string str = "";

                bool FlatBusy = ds.FlatExist(path, Convert.ToInt32(textBoxAddEntrance_NDI.Text), Convert.ToInt32(textBoxAddFlat_NDI.Text));

                if (FlatBusy)
                    MessageBox.Show("Данная должность занята", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (radioButtonBuy_NDI.Checked == true)
                            str = $"{textBoxAddEntrance_NDI.Text};{textBoxAddFlat_NDI.Text};{textBoxFIO_NDI.Text};{textBoxSumPeople_NDI.Text};{textBoxFlatArea_NDI.Text};{textBoxSumRoom_NDI.Text};покупка";
                        else
                            str = $"{textBoxAddEntrance_NDI.Text};{textBoxAddFlat_NDI.Text};{textBoxFIO_NDI.Text};{textBoxSumPeople_NDI.Text};{textBoxFlatArea_NDI.Text};{textBoxSumRoom_NDI.Text};аренда";
                    }
                    File.AppendAllText(path, str + "\n");
                    textBoxFIO_NDI.Text = "";
                    textBoxAddEntrance_NDI.Text = "";
                    textBoxFlatArea_NDI.Text = "";
                    textBoxAddFlat_NDI.Text = "";
                    textBoxSumPeople_NDI.Text = "";
                    textBoxSumRoom_NDI.Text = "";
                    radioButtonBuy_NDI.Checked = false;
                    radioButtonRent_NDI.Checked = false;
                    string[,] DataMatrix = ds.GetMatrix(path);
                    int rows = DataMatrix.GetLength(0);
                    int columns = DataMatrix.GetLength(1);
                    for (int r = 0; r <= rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            dataGridViewInfo_NDI.Rows[r].Cells[c].Value = "";
                        }
                    }

                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            dataGridViewInfo_NDI.Rows[r].Cells[c].Value = DataMatrix[r, c];
                        }
                    }
                    MessageBox.Show("Новый преподаватель зарегистрирован!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonDeletePeople_NDI_Click(object sender, EventArgs e)
        {
            if ((textBoxDeleteEntrance_NDI.Text == "") || (textBoxDeleteFlat_NDI.Text == ""))
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool FlatBusy = ds.FlatExist(path, Convert.ToInt32(textBoxDeleteEntrance_NDI.Text), Convert.ToInt32(textBoxDeleteFlat_NDI.Text));

                if (FlatBusy == false)
                    MessageBox.Show("Такого преподавателя нет в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string[] strRows = File.ReadAllLines(path);

                    for (int i = 0; i < strRows.Length; i++)
                    {
                        string[] strIndex = strRows[i].Split(';');
                        if ((strIndex[0] == textBoxDeleteEntrance_NDI.Text) && (strIndex[1] == textBoxDeleteFlat_NDI.Text))
                            strRows[i] = "";
                    }
                    strRows = strRows.Where(i => i != "").ToArray();

                    File.Delete("Университет.csv");

                    saveFileDialogInfo_NDI.FileName = "Университет.csv";
                    saveFileDialogInfo_NDI.ShowDialog();

                    path = saveFileDialogInfo_NDI.FileName;

                    File.WriteAllLines(path, strRows, Encoding.UTF8);

                    string[,] DataMatrix = ds.GetMatrix(path);

                    int rows = DataMatrix.GetLength(0);
                    int columns = DataMatrix.GetLength(1);

                    for (int r = 0; r <= rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            dataGridViewInfo_NDI.Rows[r].Cells[c].Value = "";
                        }
                    }

                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            dataGridViewInfo_NDI.Rows[r].Cells[c].Value = DataMatrix[r, c];
                        }
                    }
                    MessageBox.Show("Преподаватель уволен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            textBoxDeleteEntrance_NDI.Text = "";
            textBoxDeleteFlat_NDI.Text = "";
        }

        private void buttonOpenFile_NDI_Click(object sender, EventArgs e)
        {
            openFileDialogInfo_NDI.ShowDialog();
            string FileName = openFileDialogInfo_NDI.FileName;

            string[,] DataMatrix = ds.GetMatrix(FileName);

            int rows = DataMatrix.GetLength(0);
            int columns = DataMatrix.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = DataMatrix[r, c];
                }
            }
            buttonMaxCountPeople_NDI.Enabled = true;
            buttonMaxEntrance_NDI.Enabled = true;
            buttonMaxFlatArea_NDI.Enabled = true;
            buttonMinCountPeople_NDI.Enabled = true;
            buttonMinEntrance_NDI.Enabled = true;
            buttonMinFlatArea_NDI.Enabled = true;
            buttonBeginRent_NDI.Enabled = true;
            buttonBeginBuy_NDI.Enabled = true;
        }

        private void buttonMinEntrance_NDI_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMin(DataMatrix, 0);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_NDI.Enabled = true;
        }

        private void buttonMaxEntrance_NDI_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMax(DataMatrix, 0);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_NDI.Enabled = true;
        }

        private void buttonMinCountPeople_NDI_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMin(DataMatrix, 3);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_NDI.Enabled = true;
        }

        private void buttonMaxCountPeople_NDI_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMax(DataMatrix, 3);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_NDI.Enabled = true;
        }

        private void buttonMinFlatArea_NDI_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMin(DataMatrix, 4);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_NDI.Enabled = true;
        }

        private void buttonMaxFlatArea_NDI_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMax(DataMatrix, 4);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_NDI.Enabled = true;
        }

        private void buttonBeginRent_NDI_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMaxDataMatrix = ds.SortBeginRent(DataMatrix, 6);

            for (int r = 0; r < SortMaxDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMaxDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = SortMaxDataMatrix[r, c];
                }
            }
            buttonBack_NDI.Enabled = true;
        }

        private void buttonBeginBuy_NDI_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortBeginBuy(DataMatrix, 6);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_NDI.Enabled = true;
        }

        private void buttonBack_NDI_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);

            int rows = DataMatrix.GetLength(0);
            int columns = DataMatrix.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    dataGridViewInfo_NDI.Rows[r].Cells[c].Value = DataMatrix[r, c];
                }
            }
        }

        private void buttonAbout_NDI_Click(object sender, EventArgs e)
        {
            FormAbout_NDI formAbout = new FormAbout_NDI();
            formAbout.ShowDialog();
        }

        private void buttonHelp_NDI_Click(object sender, EventArgs e)
        {
            FormHelp_NDI formHelp = new FormHelp_NDI();
            formHelp.ShowDialog();
        }

        private void FormMain_NDI_Load(object sender, EventArgs e)
        {

        }

        private void labelFIO_NDI_Click(object sender, EventArgs e)
        {

        }

        private void labelAddEntrance_NDI_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxReg_NDI_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewInfo_NDI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelSortEntrance_NDI_Click(object sender, EventArgs e)
        {

        }
    }
}
