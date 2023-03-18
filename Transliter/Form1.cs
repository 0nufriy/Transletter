
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
                for(int j =0; j< rule.length; j++)
                {
                    if (rule[j].japan.Contains(japan_text[i]))
                    {
                        result += rule[j].ukrain;
                        break;
                    }
                }
            }
            this.textBox2.Text = result;
        }
    }
}