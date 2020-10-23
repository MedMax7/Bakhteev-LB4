using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace View
{
    /// <summary>
    /// Основная форма
    /// </summary>
    public partial class FigureForm : Form
    {
        /// <summary>
        /// Словарь типов
        /// </summary>
        private Dictionary<int, Type> _listViewFigure = 
            new Dictionary<int, Type>
        {
            [0] = typeof(Model.Ball),
            [1] = typeof(Model.Pyramid),
            [2] = typeof(Model.Parallelepiped),
        };

        /// <summary>
        /// Список фигур
        /// </summary>
        private List<FigureBase> _figureList;

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public FigureForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoad(object sender, EventArgs e)
        {
            var figureList = new List<FigureBase>();
            _figureList = figureList;
            LoadData();
        }

        /// <summary>
        /// Выбор фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewType_SelectedIndexChanged
            (object sender, EventArgs e)
        {         
            if (listViewType.SelectedItems.Count >= 1)
            {
                int firstIndex = listViewType.SelectedIndices[0];
                dataGridView.Rows.Clear();

                if (firstIndex == 0)
                {
                    dataGridView.ColumnCount = 3;
                    dataGridView.Columns[0].Name = "ID";
                    dataGridView.Columns[1].Name = "Радиус";
                    dataGridView.Columns[2].Name = "Объем";
                }
                else if (firstIndex == 1)
                {
                    dataGridView.ColumnCount = 4;
                    dataGridView.Columns[0].Name = "ID";
                    dataGridView.Columns[1].Name = "Высота";
                    dataGridView.Columns[2].Name = "Площадь основания";
                    dataGridView.Columns[3].Name = "Объем";
                }
                else if (firstIndex == 2)
                {
                    dataGridView.ColumnCount = 5;
                    dataGridView.Columns[0].Name = "ID";
                    dataGridView.Columns[1].Name = "Длина";
                    dataGridView.Columns[2].Name = "Ширина";
                    dataGridView.Columns[3].Name = "Высота";
                    dataGridView.Columns[4].Name = "Обьем";
                }
                else if (firstIndex == 3)
                {
                    dataGridView.ColumnCount = 4;
                    dataGridView.Columns[0].Name = "ID";
                    dataGridView.Columns[1].Name = "Тип фигуры";
                    dataGridView.Columns[2].Name = "Параметры";
                    dataGridView.Columns[3].Name = "Объем";
                }
                
             
                for (int i = 0; i < _figureList.Count; i++)
                {
                    if (_listViewFigure[0] != _figureList[i].GetType()) continue;

                    string[] info = _figureList[i].GetInfo().
                        Split(new char[] { ';' });

                    if (firstIndex == 0)
                    {
                        dataGridView.Rows.Add(i + 1, info[0], info[2]);
                    }
                }

                for (int i = 0; i < _figureList.Count; i++)
                {
                    if (_listViewFigure[1] != _figureList[i].GetType()) continue;

                    string[] info = _figureList[i].GetInfo().
                        Split(new char[] { ';' });

                    if (firstIndex == 1)
                    {
                        dataGridView.Rows.Add(i + 1, info[0], info[1], info[2]);
                    }
                }

                for (int i = 0; i < _figureList.Count; i++)
                {
                    if (_listViewFigure[2] != _figureList[i].GetType()) continue;

                    string[] info = _figureList[i].GetInfo().
                        Split(new char[] { ';' });

                    if (firstIndex == 2)
                    {
                        dataGridView.Rows.Add(i + 1, info[0], info[1], info[2], info[3]);
                    }
                }               

                for (int i = 0; i < _figureList.Count; i++)
                {
                    string[] info = _figureList[i].GetInfo().
                        Split(new char[] { ';' });

                    if (firstIndex == 3)
                    {
                        if (_figureList[i].GetType().Name == "Ball")
                        {
                            dataGridView.Rows.Add(i + 1,
                                _figureList[i].GetType().Name,
                                "Радиус = " + info[0], info[2]);
                        }
                        else if (_figureList[i].GetType().Name == "Pyramid")
                        {
                            dataGridView.Rows.Add(i + 1,
                                _figureList[i].GetType().Name,
                                "Площадь основания = " + info[0] +
                                "; Высота = " + info[1], info[2]);
                        }
                        else if (_figureList[i].GetType().Name == "Parallelepiped")
                        {
                            dataGridView.Rows.Add(i + 1,
                                _figureList[i].GetType().Name,
                                "Ширина = " + info[0] +
                                "; Высота = " + info[1]+
                                 "; Длина = " + info[2],
                                info[3]);
                        }
                    }                          
                }
               
            }
        }

        /// <summary>
        /// Загрузка картинок
        /// </summary>
        private void LoadData()
        {
            listViewType.Items.Clear();
            ImageList imageList = new ImageList
            {
                ImageSize = new Size(50, 50)
            };
            imageList.Images.Add(new Bitmap(Properties.Resources.Ball));
            imageList.Images.Add(new Bitmap(Properties.Resources.triangle));
            imageList.Images.Add(new Bitmap(Properties.Resources.parallelepiped));
            imageList.Images.Add(new Bitmap(Properties.Resources.sdrcgs));
            Bitmap emptyImage = new Bitmap(50, 50);
            imageList.Images.Add(emptyImage);
            listViewType.SmallImageList = imageList;
            for (int i = 0; i < 4; i++)
            {
                ListViewItem listViewItem = new ListViewItem
                    (new string[] { "" })
                {
                    ImageIndex = i
                };
                listViewType.Items.Add(listViewItem);
            }
        }


        /// <summary>
        /// Удаляем элемент из списка
        /// </summary>
        /// <param name="sender"></param>   
        /// <param name="e"></param>
        private void ButtonRemoveFigure_Click(object sender, EventArgs e)
        {
   
            try
            {
                 if (listViewType.SelectedItems.Count >= 1)
                 {
                     int firstIndex = listViewType.SelectedIndices[0];
                     foreach (DataGridViewRow row in dataGridView.
                         SelectedRows)
                     {
                         int index = dataGridView.Rows.IndexOf(row);
                         _figureList.RemoveAt(index);
                         dataGridView.Rows.Remove(row);
                     }
                 }
            }
            
            catch
            {

            }

        }

        /// <summary>
        /// Поиск строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFind_Click(object sender, EventArgs e)
        {
            FindFigureForm newForm = new FindFigureForm();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                var condition = newForm.Volume;
                for (int i = 0; i < dataGridView.RowCount - 1; i++)
                {
                    dataGridView.Rows[i].Selected = false;

                    int firstIndex = listViewType.SelectedIndices[0];
                    if (firstIndex == 0)
                    {
                        var formattedValue = dataGridView[2, i].FormattedValue.
                           ToString();
                        switch (newForm.Condition)
                        {
                            case (ConditionType.More):
                                if (Convert.ToDouble(formattedValue) >
                                    condition)
                                {
                                    dataGridView.Rows[i].Selected = true;
                                }
                                break;

                            case (ConditionType.Less):
                                if (Convert.ToDouble(formattedValue) <
                                    condition)
                                {
                                    dataGridView.Rows[i].Selected = true;
                                }
                                break;

                            case (ConditionType.Equally):
                                if (Convert.ToDouble(formattedValue) ==
                                    condition)
                                {
                                    dataGridView.Rows[i].Selected = true;
                                }
                                break;
                        }
                    }
                    else if (firstIndex == 1)
                    {
                        var formattedValue = dataGridView[3, i].FormattedValue.
                            ToString();
                        switch (newForm.Condition)
                        {
                            case (ConditionType.More):
                                if (Convert.ToDouble(formattedValue) >
                                    condition)
                                {
                                    dataGridView.Rows[i].Selected = true;
                                }
                                break;

                            case (ConditionType.Less):
                                if (Convert.ToDouble(formattedValue) <
                                    condition)
                                {
                                    dataGridView.Rows[i].Selected = true;
                                }
                                break;

                            case (ConditionType.Equally):
                                if (Convert.ToDouble(formattedValue) ==
                                    condition)
                                {
                                    dataGridView.Rows[i].Selected = true;
                                }
                                break;
                        }
                    }

                    else
                    {
                        var formattedValue = dataGridView[4, i].FormattedValue.
                            ToString();
                        switch (newForm.Condition)
                        {
                            case (ConditionType.More):
                                if (Convert.ToDouble(formattedValue) >
                                    condition)
                                {
                                    dataGridView.Rows[i].Selected = true;
                                }
                                break;

                            case (ConditionType.Less):
                                if (Convert.ToDouble(formattedValue) <
                                    condition)
                                {
                                    dataGridView.Rows[i].Selected = true;
                                }
                                break;

                            case (ConditionType.Equally):
                                if (Convert.ToDouble(formattedValue) ==
                                    condition)
                                {
                                    dataGridView.Rows[i].Selected = true;
                                }
                                break;
                        }
                    }
                }

            }
        }

        /// <summary>
		/// Добавление фигуры
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonAddFigure_Click(object sender, EventArgs e)
        {
            AddFigureForm newForm = new AddFigureForm();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                FigureBase figure = newForm.Figure;
                _figureList.Add(figure);
                MessageBox.Show("Фигура добавлена!");

                var itemNumber = 
                    _listViewFigure.FirstOrDefault(
                        x => x.Value == figure.GetType()).Key;
                listViewType.Items[itemNumber].Selected = true;

                ListViewType_SelectedIndexChanged(this, null);
                listViewType.Select();
                            
            }
        }

        /// <summary>
		/// Сохранение листа
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string path = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);
                saveFileDialog.InitialDirectory = path;
                saveFileDialog.Filter = "Figure files " +
                    "(*.fig)|*.fig|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var formatter = new BinaryFormatter();
                    var fileSave = saveFileDialog.FileName;
                    using (var fileStream = new FileStream(
                        fileSave, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fileStream, _figureList);
                        MessageBox.Show("File saved!");
                    }
                }
            }
        }

        /// <summary>
		/// Загрузка данных
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonDownload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                dataGridView.Rows.Clear();
                string path = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);
                openFileDialog.InitialDirectory = path;
                openFileDialog.Filter = "Figure files" +
                    " (*.fig)|*.fig|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var formatter = new BinaryFormatter();
                    var fileLoad = openFileDialog.FileName;

                    if (Path.GetExtension(fileLoad) == ".fig")
                    {
                        try
                        {
                            using (var fileStream = new FileStream(
                                fileLoad, FileMode.OpenOrCreate))
                            {
                                var newFigures = (List<FigureBase>)
                                    formatter.Deserialize(fileStream);

                                _figureList.Clear();

                                foreach (var figure in newFigures)
                                {
                                    _figureList.Add(figure);
                                }

                                MessageBox.Show("File loaded!");
                            }
                        }

                        catch
                        {
                            MessageBox.Show("File is corrupted, " +
                                "unable to load!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect file format " +
                            "(not *.fig)!");
                    }                   
                }

                int firstIndex = listViewType.SelectedIndices[0];

                for (int i = 0; i < _figureList.Count; i++)
                {
                    if (_listViewFigure[0] != _figureList[i].GetType()) continue;

                    string[] info = _figureList[i].GetInfo().
                        Split(new char[] { ';' });

                    if (firstIndex == 0)
                    {
                        dataGridView.Rows.Add(i + 1, info[0], info[2]);
                    }
                }

                for (int i = 0; i < _figureList.Count; i++)
                {
                    if (_listViewFigure[1] != _figureList[i].GetType()) continue;

                    string[] info = _figureList[i].GetInfo().
                        Split(new char[] { ';' });

                    if (firstIndex == 1)
                    {
                        dataGridView.Rows.Add(i + 1, info[0], info[1], info[2]);
                    }
                }

                for (int i = 0; i < _figureList.Count; i++)
                {
                    if (_listViewFigure[2] != _figureList[i].GetType()) continue;

                    string[] info = _figureList[i].GetInfo().
                        Split(new char[] { ';' });

                    if (firstIndex == 2)
                    {
                        dataGridView.Rows.Add(i + 1, info[0], info[1], info[2]);
                    }
                }

                for (int i = 0; i < _figureList.Count; i++)
                {
                    string[] info = _figureList[i].GetInfo().
                        Split(new char[] { ';' });

                    if (firstIndex == 3)
                    {
                        if (_figureList[i].GetType().Name == "Шар")
                        {
                            dataGridView.Rows.Add(i + 1,
                                _figureList[i].GetType().Name,
                                "Radius = " + info[0], info[2]);
                        }
                        else if (_figureList[i].GetType().Name == "Пирамида")
                        {
                            dataGridView.Rows.Add(i + 1,
                                _figureList[i].GetType().Name,
                                "Lenght = " + info[0] +
                                "; Width = " + info[1], info[2]);
                        }
                        else if (_figureList[i].GetType().Name == "Паралелепипед")
                        {
                            dataGridView.Rows.Add(i + 1,
                                _figureList[i].GetType().Name,
                                "Lenght = " + info[0] +
                                "; Width = " + info[1],
                                "; Heit = " + info[2], info[3]);
                        }
                    }
                }
            }              
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
