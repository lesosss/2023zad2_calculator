using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lenohka
{
    public partial class Form1 : Form
    {
        //создание обьекта random называемый randomizer
        //для создания случайный чисел
        Random randomizer = new Random();
        //целочисленые переменные integer variables
        //хранят числа для сложения - * \
        int addend1;
        int addend2;
        int minued;
        int subtrahednd;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;

        public void StartTheQuiz()
     {
            //сложение 
            //генерация 2 случайных 
            //и сохранения их в переменых ад
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            //преобразование 2 случайных числа
            //в строки для отображения их в эл управления меткой
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            //убедитесь что элемент управления = 0
            sum.Value = 0;
            //При использовании метода Next() с объектом Random, например при вызове randomizer.Next(51),
            //возвращается случайное число меньше 51 (от 0 до 50). Этот код вызывает randomizer.Next(51),
            //чтобы два случайных числа складывались и получался ответ от 0 до 100.
            //tostring для преобразования целого числа в текст который отображается в метке
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            minued = randomizer.Next(1, 101);
            
            subtrahednd = randomizer.Next(1, minued);
            minusLeftLabel.Text = minued.ToString();
            minusRightLabel.Text = subtrahednd.ToString();
            difference.Value = 0;
            
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timeRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        public Form1 () => InitializeComponent();

        public void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        } 

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minued - subtrahednd == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                //
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minued - subtrahednd;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }
    }
}//жесть
