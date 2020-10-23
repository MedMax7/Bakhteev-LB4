using System;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class FindFigureForm : Form
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public FindFigureForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Объем фигуры
        /// </summary>
        public double Volume
        {
            get; private set;
        }
        /// <summary>
        /// Условие проверки
        /// </summary>
        public ConditionType Condition
        {
            get; private set;
        }
		/// <summary>
		/// Ввод условия поиска
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonOk_Click(object sender, EventArgs e)
		{
			try
			{
				Volume = Convert.ToDouble(textBox1.Text);
				switch (comboBox1.SelectedIndex)
				{
					case (0):
						Condition = ConditionType.Less;
						break;
					case (1):
						Condition = ConditionType.More;
						break;
					case (2):
						Condition = ConditionType.Equally;
						break;
					default:
						throw new FormatException();
				}
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (FormatException)
			{
				MessageBox.Show("Incorrect data!");
			}
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
