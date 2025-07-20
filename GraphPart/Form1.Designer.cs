using System.Windows.Forms;

namespace GraphPart
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            newMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            loadMenuItem = new ToolStripMenuItem();
            assembleMenuItem = new ToolStripMenuItem();
            runMenuItem = new ToolStripMenuItem();
            stepMenuItem = new ToolStripMenuItem();
            resetMenuItem = new ToolStripMenuItem();
            this.helpMenuItem = new ToolStripMenuItem("Справка");
            dgvRegisters = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dgvMemory = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            txtProgram = new RichTextBox();
            splitContainer = new SplitContainer();
            dropdownSelector = new ComboBox();
            readOnlyTextBox1 = new TextBox();
            readOnlyTextBox2 = new TextBox();
            editorTopPanel = new Panel();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegisters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMemory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            editorTopPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, assembleMenuItem, runMenuItem, stepMenuItem, resetMenuItem, helpMenuItem});
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(784, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newMenuItem, saveMenuItem, loadMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(48, 20);
            fileMenu.Text = "Файл";
            // 
            // newMenuItem
            // 
            newMenuItem.Name = "newMenuItem";
            newMenuItem.Size = new Size(133, 22);
            newMenuItem.Text = "Новый";
            newMenuItem.Click += newMenuItem_Click;
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.Size = new Size(133, 22);
            saveMenuItem.Text = "Сохранить";
            saveMenuItem.Click += saveMenuItem_Click;
            // 
            // loadMenuItem
            // 
            loadMenuItem.Name = "loadMenuItem";
            loadMenuItem.Size = new Size(133, 22);
            loadMenuItem.Text = "Загрузить";
            loadMenuItem.Click += loadMenuItem_Click;
            // 
            // assembleMenuItem
            // 
            assembleMenuItem.Name = "assembleMenuItem";
            assembleMenuItem.Size = new Size(114, 20);
            assembleMenuItem.Text = "Скомпилировать";
            assembleMenuItem.Click += assembleMenuItem_Click;
            // 
            // runMenuItem
            // 
            runMenuItem.Name = "runMenuItem";
            runMenuItem.Size = new Size(74, 20);
            runMenuItem.Text = "Запустить";
            runMenuItem.Click += runMenuItem_Click;
            // 
            // stepMenuItem
            // 
            stepMenuItem.Name = "stepMenuItem";
            stepMenuItem.Size = new Size(41, 20);
            stepMenuItem.Text = "Шаг";
            stepMenuItem.Click += stepMenuItem_Click;
            // 
            // resetMenuItem
            // 
            resetMenuItem.Name = "resetMenuItem";
            resetMenuItem.Size = new Size(54, 20);
            resetMenuItem.Text = "Сброс";
            resetMenuItem.Click += resetMenuItem_Click;

            helpMenuItem.Click += ShowHelp;
            menuStrip.Items.Add(helpMenuItem);
            // 
            // dgvRegisters
            // 
            dgvRegisters.AllowUserToAddRows = false;
            dgvRegisters.AllowUserToDeleteRows = false;
            dgvRegisters.BackgroundColor = SystemColors.Control;
            dgvRegisters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegisters.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dgvRegisters.Dock = DockStyle.Top;
            dgvRegisters.Location = new Point(0, 0);
            dgvRegisters.Name = "dgvRegisters";
            dgvRegisters.ReadOnly = true;
            dgvRegisters.Size = new Size(305, 126);
            dgvRegisters.TabIndex = 1;
            
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Регистр/Флаг";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 162;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Значение";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;

            dgvRegisters.Rows.Add("Память[A1]", 0);
            dgvRegisters.Rows.Add("Память[A2]", 0);
            dgvRegisters.Rows.Add("Память[A3]", 0);
            dgvRegisters.Rows.Add("Флаг переполнения", "000");
            // 
            // dgvMemory
            // 
            dgvMemory.AllowUserToAddRows = false;
            dgvMemory.AllowUserToDeleteRows = false;
            dgvMemory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvMemory.BackgroundColor = SystemColors.Control;
            dgvMemory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMemory.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvMemory.Dock = DockStyle.Fill;
            dgvMemory.Location = new Point(0, 126);
            dgvMemory.Name = "dgvMemory";
            dgvMemory.ReadOnly = true;
            dgvMemory.Size = new Size(305, 285);
            dgvMemory.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Адрес";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "PC";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 47;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Код";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 52;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Мнемоника";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 98;
            // 
            // txtProgram
            // 
            txtProgram.AcceptsTab = true;
            txtProgram.Dock = DockStyle.Fill;
            txtProgram.Font = new Font("Consolas", 10F);
            txtProgram.Location = new Point(0, 0);
            txtProgram.Name = "txtProgram";
            txtProgram.Size = new Size(451, 411);
            txtProgram.TabIndex = 0;
            txtProgram.Text = "";
            this.txtProgram.TextChanged += txtProgram_TextChanged;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(12, 38);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dgvMemory);
            splitContainer.Panel1.Controls.Add(dgvRegisters);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtProgram);
            this.splitContainer.Panel2.Controls.Add(this.editorTopPanel);
            splitContainer.Size = new Size(760, 411);
            splitContainer.SplitterDistance = 305;
            splitContainer.TabIndex = 0;
            // 
            // dropdownSelector
            // 
            dropdownSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            dropdownSelector.Items.AddRange(new object[] { "Компиляция", "Декомпиляция" });
            dropdownSelector.Location = new Point(0, 0);
            dropdownSelector.Name = "dropdownSelector";
            dropdownSelector.Size = new Size(150, 23);
            dropdownSelector.TabIndex = 0;
            dropdownSelector.SelectedIndex = 0;
            // 
            // readOnlyTextBox1
            // 
            readOnlyTextBox1.Location = new Point(160, 0);
            readOnlyTextBox1.Name = "readOnlyTextBox1";
            readOnlyTextBox1.ReadOnly = true;
            readOnlyTextBox1.Size = new Size(290, 23);
            readOnlyTextBox1.TabIndex = 1;
            readOnlyTextBox1.Text = "Для запуска программы проведите компиляцию!";
            // 
            // readOnlyTextBox2
            // 
            readOnlyTextBox2.Location = new Point(0, 25);
            readOnlyTextBox2.Name = "readOnlyTextBox2";
            readOnlyTextBox2.ReadOnly = true;
            readOnlyTextBox2.Size = new Size(450, 23);
            readOnlyTextBox2.TabIndex = 2;
            readOnlyTextBox2.Text = "Ошибка компиляции: Отсутствует.";
            // 
            // editorTopPanel
            // 
            editorTopPanel.Controls.Add(dropdownSelector);
            editorTopPanel.Controls.Add(readOnlyTextBox1);
            editorTopPanel.Controls.Add(readOnlyTextBox2);
            editorTopPanel.Dock = DockStyle.Top;
            editorTopPanel.Location = new Point(0, 0);
            editorTopPanel.Name = "editorTopPanel";
            editorTopPanel.Size = new Size(200, 50);
            editorTopPanel.TabIndex = 0;
            // 
            // Form1
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(splitContainer);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "Form1";
            Text = "Лучше чем КР580";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegisters).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMemory).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            editorTopPanel.ResumeLayout(false);
            editorTopPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
