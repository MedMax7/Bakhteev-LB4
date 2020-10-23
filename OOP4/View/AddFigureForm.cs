using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Форма добавления фигуры
    /// </summary>
    public partial class AddFigureForm : Form
    {
        /// <summary>
        /// Словарь фигур
        /// </summary>		
        private Dictionary<FigureType, string> _figureKey =
            new Dictionary<FigureType, string>
            {
                [FigureType.Ball] = "Шар",
                [FigureType.Pyramid] = "Пирамида",
                [FigureType.Parallelepiped] = "Паралелепипед",
            };

        /// <summary>
        /// Получение FigureBase
        /// </summary>
        public FigureBase Figure
        {
            get; private set;
        }

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public AddFigureForm()
        {
            InitializeComponent();
            Shown += AddFigureForm_Shown;
        }

        /// <summary>
		/// Открытие формы добавления фигуры
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void AddFigureForm_Shown(object sender, EventArgs e)
        {
            comboBoxType.Items.Add(_figureKey[FigureType.Ball]);
            comboBoxType.Items.Add(_figureKey[FigureType.Pyramid]);
            comboBoxType.Items.Add(_figureKey[FigureType.Parallelepiped]);

            if (comboBoxType.Text == _figureKey[FigureType.Ball])
            {
                maskedTextBox1.Enabled = true;
            }
            else if (comboBoxType.Text == _figureKey[FigureType.Parallelepiped])
            {
                maskedTextBox1.Enabled = true;
                maskedTextBox2.Enabled = true;
                maskedTextBox3.Enabled = true;
            }
            else
            {
                maskedTextBox2.Enabled = true;
                maskedTextBox3.Enabled = true;
            }
        }

        /// <summary>
        /// Активация спец. полей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>	
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Visible = false;
            maskedTextBox2.Visible = false;
            maskedTextBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            if (comboBoxType.Text == _figureKey[FigureType.Ball])
            {
                label1.Visible = true;
                maskedTextBox1.Visible = true;
            }
            else if (comboBoxType.Text == _figureKey[FigureType.Pyramid])
            {
                label2.Visible = true;
                label3.Visible = true;
                label2.Text = "Площадь основания:";
                label3.Text = "Высота:";
                maskedTextBox2.Visible = true;
                maskedTextBox3.Visible = true;
            }
            else if (comboBoxType.Text == _figureKey[FigureType.Parallelepiped])
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label2.Text = "Ширина:";
                label3.Text = "Длина:";
                label1.Text = "Высота:";
                maskedTextBox1.Visible = true;
                maskedTextBox2.Visible = true;
                maskedTextBox3.Visible = true;
            }
        }

        /// <summary>
		/// Закрыть форму
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Добавление фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>		
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            FigureBase figure = null;
            try
            {
                if (comboBoxType.Text == _figureKey[FigureType.Ball])
                {
                    figure = new Ball(GetCorrect(Convert.ToDouble, maskedTextBox1.Text));
                }

                if (comboBoxType.Text == _figureKey[FigureType.Pyramid])
                {
                    figure = new Pyramid(GetCorrect(Convert.ToDouble, maskedTextBox2.Text),
                            GetCorrect(Convert.ToDouble, maskedTextBox3.Text));
                }
                
                if (comboBoxType.Text == _figureKey[FigureType.Parallelepiped])
                {
                    figure = new Parallelepiped(GetCorrect(Convert.ToDouble, maskedTextBox2.Text),
                            GetCorrect(Convert.ToDouble, maskedTextBox3.Text), GetCorrect(Convert.ToDouble, maskedTextBox1.Text));
                }

                Figure = figure ?? throw new ArgumentException("Тип не выбран!");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Неверные данные!");
            }

        }

        /// <summary>
        /// Проверка на корректность ввода
        /// </summary>
        /// <typeparam name="T">Требуемый тип</typeparam>
        /// <param name="convert">Параметр</param>
        /// <param name="text">Входная строка</param>
        /// <returns></returns>
        private static T GetCorrect<T>(Func<string, T> convert, string text)
        {
            try
            {
                return convert.Invoke(text);
            }
            catch (FormatException)
            {
                return default;
            }
        }
        /// <summary>
        /// Создать рандомную фигуру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>		
        private void ButtonRandom_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = maskedTextBox2.Text = maskedTextBox3.Text = " ";
            Random random = new Random();
            comboBoxType.SelectedIndex = random.Next(0, 3);
            
            if (comboBoxType.Text == _figureKey[FigureType.Ball])
            {
                maskedTextBox1.Text = Convert.ToString(random.Next(1, 50));
            }
            else if (comboBoxType.Text == _figureKey[FigureType.Parallelepiped])
            {
                maskedTextBox1.Text = Convert.ToString(random.Next(1, 50));
                maskedTextBox2.Text = Convert.ToString(random.Next(1, 50));
                maskedTextBox3.Text = Convert.ToString(random.Next(1, 50));
            }
            else
            {
                maskedTextBox2.Text = Convert.ToString(random.Next(1, 50));
                maskedTextBox3.Text = Convert.ToString(random.Next(1, 50));
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
