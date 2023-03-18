﻿
using Newtonsoft.Json;
namespace Transliter
{
    public partial class Form1 : Form
    {

        ABC rule;

        public Form1()
        {
            InitializeComponent();
            try
            {
                ABC? rule1 = JsonConvert.DeserializeObject<ABC>(File.ReadAllText("rule.json"));
                if (rule1 != null)
                {
                    this.rule = rule1;
                }
                else
                {
                    label3.Text = "Помилка при читанні файлу, перевірте його наявність та перезапустіть программу";
                }
            }
            catch
            {
                label3.Text = "Помилка при читанні файлу, перевірте його наявність та перезапустіть программу";
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rule == null)
            {
                return;
            }
            char[] japan_text = textBox1.Text.ToCharArray();
            string result = "";
            for(int i = 0; i < japan_text.Length; i++)
            {
                for(int j = rule.length-1; j>=0; j--)
                {
                    string[] gg = rule[j].japan.Replace(" ","").Trim().Split("/");
                    
                    for(int g=0; g< gg.Length; g++)
                    {
                        string cont = "";
                        if (i + gg[g].Trim().Length <= japan_text.Length)
                        {
                            for (int h = 0; h < gg[g].Trim().Length; h++)
                            {
                                cont += japan_text[i + h];
                            }
                            if (gg[g].Trim() == cont)
                            {
                                result += rule[j].ukrain;
                                i += gg[g].Trim().Length - 1;
                                break;
                            }
                        }
                       
                    }

                    
                }
            }
            this.textBox2.Text = result;
        }
    }
}