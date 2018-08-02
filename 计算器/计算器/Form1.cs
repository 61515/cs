using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计算器
{
    public partial class Form1 : Form
    {
        public Stack<int> a;
        public Stack<char> b;
        public int lenth;
        public int item;
        int flag = 0;
        public char[,]
        fuck = new char[,] {
                { '>', '>', '<','<','<','>','>' },
                { '>', '>', '<','<','<','>','>' },
                { '>', '>', '>','>','<','>','>' },
                { '>', '>', '>','>','<','>','>' },
                { '<', '<', '<','<','<','=','!' },
                { '>', '>', '>','>','!','>','>' },
                { '<', '<', '<','<','<','!','=' },
            };
        int x, y;
        char z;
        string result = "";
        string s = "";
        int temp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (char xh in textBox1.Text)
            {
                flag = 0;
                if (xh >= '0' && xh <= '9' || xh == '(' || xh == ')' || xh == '+' || xh == '-' || xh == '*' || xh == '/' || xh == '#') { }
                else
                {
                    MessageBox.Show("请输入正确的表达式", "表达式错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
            }
            foreach(Char xh in textBox1.Text.Substring(0, textBox1.Text.Length - 1))
            {
                if (xh >= '0' && xh <= '9') { }
                else flag = 1;
            }
            if(flag==0)
            {
                MessageBox.Show(textBox1.Text, "计算结果");
                return;
            }
            try
            {
                a = new Stack<int>();
                b = new Stack<char>();
                b.Push('#');
                lenth = textBox1.TextLength;
                textBox1.Text += '#';
                char ch;
                item = 0;
                ch = textBox1.Text[item++];
                result = "";
                s = "";
                while (ch != '#' || b.Peek() != '#')
                {
                    if (!In(ch))
                    {
                        s += ch;
                        ch = textBox1.Text[item++];
                    }
                    else
                    {
                        if (s != "")
                        {
                            temp = Convert.ToInt32(s);
                            a.Push(temp);
                            s = "";
                        }
                        switch (precede(b.Peek(), ch))
                        {
                            case '<':
                                b.Push(ch);
                                ch = textBox1.Text[item++]; break;
                            case '=':
                                b.Pop(); ch = textBox1.Text[item++]; break;
                            case '>':
                                x = a.Pop();
                                y = a.Pop();
                                z = b.Pop();
                                a.Push(Operate(x, y, z));
                                break;
                        }
                    }
                }
                result += a.Peek();
                MessageBox.Show(result, "计算结果", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                try
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

                }
                catch
                {
                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("表达式错误","错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }
        public bool In(Char x)
        {
            if (x >= '0' && x <= '9')
                return false;
            return true;
        }
        public char precede(char x,char y)
        {
            int i=7, j=7;
            switch(x)
            {
                case '+':i = 0;break;
                case '-':i = 1;break;
                case '*': i = 2; break;
                case '/': i = 3; break;
                case '(': i = 4; break;
                case ')': i = 5; break;
                case '#': i = 6; break;
            }
            switch (y)
            {
                case '+': j= 0; break;
                case '-': j = 1; break;
                case '*': j = 2; break;
                case '/': j = 3; break;
                case '(': j = 4; break;
                case ')': j = 5; break;
                case '#': j = 6; break;
            }
            if (i >= 0 && i < 7 && j >= 0 && j < 7) return fuck[i,j];
            else return 'H';



        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += '1';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += '2';
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += '3';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += '4';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += '5';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += '6';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += '7';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += '8';
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += '9';
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += '0';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += '*';
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += '/';
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += '+';
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += '-';
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

            }
            catch
            {
                textBox1.Focus();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text += '(';
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += ')';
        }

        int Operate(int x,int y,char z)
        {
            switch(z)
            {
                case '+':
                    return y + x;
                case '-':
                    return y - x;
                case '*':
                    return y * x;
                case '/':
                    return y / x;
            }
            return -1;

        }
    }
}
