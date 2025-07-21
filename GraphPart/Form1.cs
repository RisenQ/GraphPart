using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GraphPart
{
    public partial class Form1 : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newMenuItem;
        private ToolStripMenuItem loadMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem assembleMenuItem;
        private ToolStripMenuItem runMenuItem;
        private ToolStripMenuItem stepMenuItem;
        private ToolStripMenuItem resetMenuItem;
        private ToolStripMenuItem helpMenuItem;

        private DataGridView dgvRegisters;
        private DataGridView dgvMemory;
        private RichTextBox txtProgram;
        private SplitContainer splitContainer;
        private ComboBox dropdownSelector;
        private TextBox readOnlyTextBox1;
        private TextBox readOnlyTextBox2;
        private Panel editorTopPanel;
        private string[] parts;
        private byte[] decData;
        private string made;
        private int currentIndex = 1;
        private int curr = 0;
        private bool state = false;
        private int[] regs = new int[5];
        private bool end = true;
        private bool compiled = false;
        private int byteNow = 1;


        public Form1()
        {
            InitializeComponent();
        }
        private void newMenuItem_Click(object sender, EventArgs e) => txtProgram.Clear();
        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Файлы ассемблера|*.asm;*.txt|Все файлы|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtProgram.Text = File.ReadAllText(dlg.FileName);
            }
        }
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Файлы ассемблера|*.asm;*.txt|Все файлы|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dlg.FileName, txtProgram.Text);
            }
        }

        // Action menu handlers
        private void assembleMenuItem_Click(object sender, EventArgs e)
        {
            string inputText;
            if (dropdownSelector.SelectedIndex == 0)
                inputText = "1\n" + txtProgram.Text;
            else
                inputText = "0\n" + txtProgram.Text;
            string result = RunProgram1("AssemblyCompilerMK4.exe", inputText);
            if (result[0] == 'E')
            {
                Error(result);
                return;
            }
            result = result.Substring(3, result.Length - 4);
            if (dropdownSelector.SelectedIndex == 0)
                Assemble(result);
            else
                Disassemble(result);
        }
        private void Assemble(string s)
        {
            decData = ConvertToByteCode(s);
            File.WriteAllBytes("compiled.bin", decData);
            readOnlyTextBox2.Text = "Программа скомпилирована без ошибок";
            compiled = true;
            readOnlyTextBox1.BackColor = Color.White;
            readOnlyTextBox1.Text = "Программа готова к запуску";
            made = RunProgram1("AssemblyCompilerMK4.exe", "0\n" + s);
            GetReadyPC(s);
        }
        private void Disassemble(string s)
        {
            readOnlyTextBox2.Text = "Программа декомпилирована без ошибок";
            txtProgram.Text = s;
        }
        private void GetReadyPC(string s)
        {
            if (dgvMemory.Rows.Count > 0)
            {
                dgvMemory.Rows.Clear();
                byteNow = 1;
            }
                
            string[] tempStr = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] tempStr2 = made.Substring(3, made.Length - 4).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0, j = 0; j < tempStr2.Length; j++, i++)
            {
                switch (tempStr2[j].Substring(0, 4))
                {
                    case "MOV ":
                        dgvMemory.Rows.Add(byteNow, "", tempStr[i] + tempStr[i+1], tempStr2[j]);
                        i++;
                        byteNow += 2;
                        break;
                    default:
                        dgvMemory.Rows.Add(byteNow, "", tempStr[i], tempStr2[j]);
                        byteNow++;
                        break;
                }

            }
        }
        private void Error(string s)
        {
            readOnlyTextBox2.Text = "Ошибка компиляции: " + s;
        }
        private async void runMenuItem_Click(object sender, EventArgs e)
        {
            if (compiled)
            {
                runMenuItem.Text = runMenuItem.Text == "Запустить" ? "Остановить" : "Запустить";
                if (state)
                    state = false;
                else
                {
                    if (end)
                    {
                        newStart();
                    }
                    state = true;
                    for (int i = currentIndex; !state || i < parts.Length; i++)
                    {
                        await Task.Delay(100);
                        Start(parts[i]);
                        end = false;
                        if (i == parts.Length - 1 || state == false)
                            break;
                    }
                    runMenuItem.Text = "Запустить";
                    if (currentIndex == parts.Length-1)
                    {
                        currentIndex = 1;
                        curr = 0;
                        end = true;
                        state = false;
                    }
                }
            }
            else
            {
                readOnlyTextBox1.BackColor = Color.Red;
            }
        }
        private void Start(string partsi)
        {
            string[] tempStr = partsi.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < 5; j++)
                regs[j] = Int32.Parse(tempStr[j]);
            ChangeRegs(regs);
            if (curr != 0)
                dgvMemory.Rows[curr - 1].Cells[1].Value = "";
            if (curr < dgvMemory.Rows.Count)
            {
                dgvMemory.Rows[curr].Cells[1].Value = ">>>>";
                curr++;
            }
            else
            {
                currentIndex = 1;
                curr = 0;
                end = true;
                state = false;
            }
            dgvRegisters.Refresh();
            currentIndex++;
        }
        private void ChangeRegs(int[] r)
        {
            dgvRegisters.Rows[0].Cells[1].Value = r[1];
            dgvRegisters.Rows[1].Cells[1].Value = r[2];
            dgvRegisters.Rows[2].Cells[1].Value = r[3];
            dgvRegisters.Rows[3].Cells[1].Value = r[4];
        }
        private void stepMenuItem_Click(object sender, EventArgs e)
        {
            if (parts == null || currentIndex == parts.Length-1) return;
            Start(parts[currentIndex]);
        }
        private void resetMenuItem_Click(object sender, EventArgs e)
        {
            end = true;
            state = false;
            currentIndex = 1;
            dgvMemory.Rows[curr-1].Cells[1].Value = "";
            curr = 0;
            ChangeRegs([0,0,0,0,0]);
            newStart();
        }
        private void txtProgram_TextChanged(object sender, EventArgs e)
        {
            compiled = false;
            readOnlyTextBox1.Text = "Для запуска программы проведите компиляцию!";
        }
        private void newStart()
        {
            string result = RunProgram2("Emulator.exe");
            parts = result.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
        private string RunProgram1(string executablePath, string inputText)
        {
            Process process = new Process();
            process.StartInfo.FileName = executablePath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.StandardInput.Write(inputText);
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
        private string RunProgram2(string executablePath)
        {
            Process process = new Process();
            process.StartInfo.FileName = executablePath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.StandardInput.Write(new StreamReader("compiled.bin").ReadToEnd());
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
        public static byte[] ConvertToByteCode(string bitString)
        {
            string z = "00000000";
            var bits = new string(bitString
                .Where(c => c == '0' || c == '1')
                .ToArray());

            if (bits.Length % 8 != 0)
                throw new Exception("Строка битов должна быть кратна 8");

            int byteCount = bits.Length / 8;
            byte[] result = new byte[2047];
            int i;
            for (i = 0; i < byteCount; i++)
            {
                string byteBits = bits.Substring(i * 8, 8);
                result[i] = Convert.ToByte(byteBits, 2);
            }
            for (int j = i; j < 2047; j++)
            {
                result[i] = Convert.ToByte(z, 2);
            }
            
            return result;
        }
        private void ShowHelp(object sender, EventArgs e)
        {
            string message =
                "Код   Мнемокод       Описание\n" +
                "00000 MOVA1 const   A1 = константа\n" +
                "00001 MOVA2 const   A2 = константа\n" +
                "00010 MOVA3 const   A3 = константа\n" +
                "00100 ADD страница  Память[A3] = Память[A1] + Память[A2]\n" +
                "00101 ADC страница  Память[A3] = Память[A1] + Память[A2] + флаг перен.\n" +
                "00110 SUB страница  Память[A3] = Память[A1] - Память[A2]\n" +
                "00111 SBB страница  Память[A3] = Память[A1] - Память[A2] - флаг перен.\n" +
                "01000 MUL страница  Память[A3] = Память[A1] * Память[A2]\n" +
                "01001 DIV страница  Память[A3] = Память[A1] / Память[A2]\n" +
                "01010 MOD страница  Память[A3] = Память[A1] % Память[A2]\n" +
                "01011 ABS страница  Память[A3] = |Память[A1]|\n" +
                "01100 AND страница  Память[A3] = Память[A1] & Память[A2]\n" +
                "01101 OR страница   Память[A3] = Память[A1] | Память[A2]\n" +
                "01110 XOR страница  Память[A3] = Память[A1] ^ Память[A2]\n" +
                "01111 NOT страница  Память[A3] = not Память[A1]\n" +
                "10000 JMP страница  Переход по адресу A3\n" +
                "10001 JB страница   Переход по адресу A3, если результат < 0\n" +
                "10010 JNZ страница  Переход по адресу A3, если результат != 0\n" +
                "10011 MOVS         Память[A3] = A1, A3 += 1, A1 += 1\n" +
                "10101 CMPS         Сравнение Память[A1] и Память[A3]\n\n" +
                "Флаг переполнения: представляет собой 3 бита (значение от 0 до 7),\n" +
                "где первый бит означает переполнение, второй бит - результат меньше нуля, третий - не равен нулю.\n" +
                "Флаг 4 ознчает 100, Флаг 1 = 001 и т.д.";


            MessageBox.Show(message, "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /*
         * dgvRegisters.Rows.Add("Память[A1]", 0);
            dgvRegisters.Rows.Add("Память[A2]", 0);
            dgvRegisters.Rows.Add("Память[A3]", 0);
            dgvRegisters.Rows.Add("Флаг переполнения", "000");
         * */
    }
}
