using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeArtEng.GameControls;

namespace FlashCard
{
    internal partial class SelectionDialog : Form
    {
        private Size ButtonSize;
        private Dictionary<string, SelectionDialogItem> _Items;

        public SelectionDialog()
        {
            InitializeComponent();
            lbDesc.Text = string.Empty;

            ButtonSize = refButton.Size;
            refButton.Dispose();

            ItemsBackColor = Color.FromKnownColor(KnownColor.Control);
            ItemsForeColor = Color.FromKnownColor(KnownColor.ControlText);

            AllowToCancel = true;
            ShowDescription = false;

            _Items = new Dictionary<string, SelectionDialogItem>();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        private bool SupressEvents = false;
        private void RefreshControls()
        {
            SupressEvents = true;

            //Clean up old objects
            ItemsPanel.Controls.Clear();

            //Build items list
            OptionButton newButton;
            SelectionDialogItem ptrItem;

            string[] keys = new string[_Items.Keys.Count];
            _Items.Keys.CopyTo(keys, 0);
            for(int x=keys.Length - 1; x >= 0; x--)
            {
                //** Workaround to arrange docked item, create in reverse order **
                ptrItem = _Items[keys[x]];
                newButton = new OptionButton();
                newButton.ForeColor = ItemsForeColor;
                newButton.BackColor = ItemsBackColor;
                newButton.Dock = DockStyle.Top;
                newButton.Size = ButtonSize;
                newButton.Parent = ItemsPanel;
                newButton.Text = ptrItem.Text;
                newButton.DialogResult = System.Windows.Forms.DialogResult.OK;
                newButton.Click += new EventHandler(newButton_Click);
                newButton.MouseEnter += new EventHandler(newButton_MouseEnter);
                newButton.Enter += new EventHandler(newButton_Enter);
                newButton.Enabled = ptrItem.Enabled;
            }

            int tabIndex = 0;
            for (int x = ItemsPanel.Controls.Count - 1; x >= 0; x--)
            {
                //** Workaround to fix incorrect tab index **
                ItemsPanel.Controls[x].TabIndex = tabIndex++;
            }
            SelectedItem = string.Empty;
            SupressEvents = false;
        }

        public void ClearItems() { _Items.Clear(); }
        public SelectionDialogItem AddItem(string item)
        {
            SelectionDialogItem newItem = new SelectionDialogItem(item);
            _Items.Add(item, newItem);
            return newItem;
        }
        public SelectionDialogItem FindItem(string item)
        {
            if (_Items.ContainsKey(item)) return _Items[item];
            return null;
        }

        private Color _ItemsBackColor;
        public Color ItemsBackColor
        {
            get { return _ItemsBackColor; }
            set
            {
                _ItemsBackColor = value;
                foreach (OptionButton ptrButton in ItemsPanel.Controls)
                    ptrButton.BackColor = _ItemsBackColor;
            }
        }
        private Color _ItemsFontColor;
        public Color ItemsForeColor
        {
            get { return _ItemsFontColor; }
            set
            {
                _ItemsFontColor = value;
                foreach (OptionButton ptrButton in ItemsPanel.Controls)
                    ptrButton.ForeColor = value;
            }
        }
        private Color _ItemsHoverColor;
        public Color ItemsHowverColor
        {
            get { return _ItemsHoverColor; }
            set
            {
                _ItemsHoverColor = value;
                foreach (OptionButton ptrButton in ItemsPanel.Controls)
                    ptrButton.HoverColor = value;
            }
        }

        public void EnableItem(string item) { ItemEnabled(item, true); }
        public void DisableItem(string item) { ItemEnabled(item, false); }
        private void ItemEnabled(string item, bool flag) { _Items[item].Enabled = flag; }

        public string SelectedItem { get; private set; }
        void newButton_Click(object sender, EventArgs e)
        {
            SelectedItem = ((Button)sender).Text;
        }
        void newButton_MouseEnter(object sender, EventArgs e)
        {
            if (SupressEvents) return;
            ShowDescriptionImage(sender);
        }
        private void newButton_Enter(object sender, EventArgs e)
        {
            if (SupressEvents) return;
            ShowDescriptionImage(sender);
        }
        private void ShowDescriptionImage(object sender)
        {
            SelectionDialogItem item = _Items[((Button)sender).Text];
            picDesc.Image = item.DescriptionImage;
        }


        public bool AllowToCancel
        {
            get { return BtCancel.Visible; }
            set { BtCancel.Visible = value; }
        }
        public bool ShowDescription
        {
            get { return PnDescription.Visible; }
            set { PnDescription.Visible = value; }
        }
        public string CancelButtonText
        {
            get { return BtCancel.Text; }
            set { BtCancel.Text = value; }
        }

        private void SelectionDialog_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true) RefreshControls();
        }

        private void BtCancel_MouseEnter(object sender, EventArgs e)
        {
            picDesc.Image = null;
        }
    }

    internal class SelectionDialogItem
    {
        public SelectionDialogItem(string text)
        {
            Text = text;
            Enabled = true;
        }
        public string Text { get; set; }
        public bool Enabled { get; set; }
        public Image DescriptionImage { get; set; }
        public string Description { get; set; }
    }
}
