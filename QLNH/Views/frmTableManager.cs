﻿using QLNH.DAO;
using QLNH.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = QLNH.Model.Menu;
using Properties = QLNH.Properties;

namespace QLNH.Views
{
    public partial class frmTableManager : Form
    {
        // singleton
        private Account loginAccount;
        private static int idFoodByClick = -1;
        private static int idCategoryByClick = -1;

        public Account LoginAccount 
        {
            get { return loginAccount; }
            set { loginAccount = value;} 
        }

        public frmTableManager(Account acc)
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            setIconButton();

            this.loginAccount = acc;
            changeAccount(acc.Type);

            LoadTable();
            LoadCategory();
            LoadComboBoxTable(cbSwitchTable);
        }

        #region Method
        private void setIconButton()
        {
            // button Add Food
            btnAddFood.Image = IconDAO.Instance.setIconButtonAndImage("icons8-add-reminder-24.png");

            // button Pay
            btnCheck.Image = IconDAO.Instance.setIconButtonAndImage("icons8-mobile-payment-30.png");
            btnCheck.TextImageRelation = TextImageRelation.ImageBeforeText;

            // button Switch Table
            btnSwitchTable.Image = IconDAO.Instance.setIconButtonAndImage("icons8-switch-24.png");

            // admin Tool Strip Menu Item
            adminToolStripMenuItem.Image = IconDAO.Instance.setIconButtonAndImage("icons8-admin-settings-male-48.ico");

            //account Information Tool Strip Menu Item
            accountInformationToolStripMenuItem.Image = IconDAO.Instance.setIconButtonAndImage("icons8-personal-information-64.ico");

            //personal Tool Strip Menu Item
            personalToolStripMenuItem.Image = IconDAO.Instance.setIconButtonAndImage("icons8-account-64.ico");

            //logout Tool Strip Menu Item
            logoutToolStripMenuItem.Image = IconDAO.Instance.setIconButtonAndImage("icons8-logout-58.ico");

            //function Tool Strip Menu Item
            functionToolStripMenuItem.Image = IconDAO.Instance.setIconButtonAndImage("icons8-functionality-64.ico");

            //pay Tool Strip Menu Item
            payToolStripMenuItem.Image = IconDAO.Instance.setIconButtonAndImage("icons8-mobile-payment-30.png");

            //add Food Tool Strip Menu Item
            addFoodToolStripMenuItem.Image = IconDAO.Instance.setIconButtonAndImage("icons8-add-reminder-24.png");

            //button Search Table
            btnSearchTable.Image = IconDAO.Instance.setIconButtonAndImage("icons8-search-24.png");

            //button Search Food
            btnSearchFood.Image = IconDAO.Instance.setIconButtonAndImage("icons8-search-24.png");

            //btn Recall
            btnRecall.Image = IconDAO.Instance.setIconButtonAndImage("icons8-enter-key-24.png");

            //btn Return
            btnReturn.Image = IconDAO.Instance.setIconButtonAndImage("icons8-return-24.png");

            //picturebox Table
            ptbTable.Image = IconDAO.Instance.setIconButtonAndImage("restaurant-table.png");

            //button All Food
            btnAllFood.Image = IconDAO.Instance.setIconButtonAndImage("icons8-all-24.png");
        }

        void changeAccount(int type)
        {
            // admin button hiệu lực khi loại người dùng là admin
            adminToolStripMenuItem.Enabled = (type == 1);

            // hiện thông tin username lên tool strip menu
            accountInformationToolStripMenuItem.Text += " (" + loginAccount.DisplayName + ")";
        }

        void LoadCategory()
        {
            // lấy danh sách Category
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            
            // đổ vào ComboBox
            //cbCategory.DataSource = listCategory;

            // hiện trường dữ liệu là Name
            //cbCategory.DisplayMember = "Name";

            flpCategory.Controls.Clear();
            foreach (Category item in listCategory)
            {
                // tạo button width và height
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                //btn.Font = new Font(btn.Font, FontStyle.Bold);

                string filename = item.Image;

                btn.Image = IconDAO.Instance.setIconButtonAndImage(filename);
                btn.TextImageRelation = TextImageRelation.ImageAboveText;

                // set event
                btn.Click += btn_ClickCategory;
                // lưu item vào button
                btn.Tag = item;

                // thêm button vào flow layout panel
                flpCategory.Controls.Add(btn);
            }

        }

        void LoadFood(List<Food> listFood)
        {
            flpFood.Controls.Clear();
            foreach (Food item in listFood)
            {
                Button btnFood = new Button() { Width = FoodDAO.FoodWidth, Height = FoodDAO.FoodHeight };

                CultureInfo culture = new CultureInfo("vi-VN"); //en-US
                btnFood.Text = item.Name + "\n" + item.Price.ToString("c", culture).Replace(",00", "");
                btnFood.TextImageRelation = TextImageRelation.ImageAboveText;
                string filename = item.Image;
                btnFood.Image = IconDAO.Instance.setIconButtonAndImage(filename);
                btnFood.BackColor = Color.White;

                btnFood.Click += BtnFood_Click;
                // lưu item vào button
                btnFood.Tag = item;

                flpFood.Controls.Add(btnFood);
            }
        }



        // load danh sách Food từ id Category
        void LoadFoodListByCategoryID(int id)
        {
            // lấy data Food
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);

            // đổ vào ComboBox
            //cbFood.DataSource = listFood;

            // hiện trường dữ liệu là Name
            //cbFood.DisplayMember = "Name";

            LoadFood(listFood);
            
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();

            //lấy data
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            
            foreach(Table item in tableList)
            {
                // tạo button width và height
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status; // Environment.NewLine = \n
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.Font = new Font(btn.Font, FontStyle.Bold);

                // set event
                btn.Click += btn_Click;

                // lưu item vào button
                btn.Tag = item;

                // set màu cho status
                switch (item.Status)
                {
                    case "Empty":

                        // button Add Food
                        btn.Image = IconDAO.Instance.setIconButtonAndImage("icons8-table-47.png");
                        btn.ImageAlign = ContentAlignment.TopCenter;
                        btn.BackColor = Color.LightYellow;
                        break;
                    default:
                        btn.Image = IconDAO.Instance.setIconButtonAndImage("icons8-table-49.png");
                        //btn.Image = Properties.Resources.icons8_table_49;
                        btn.ImageAlign = ContentAlignment.TopCenter;
                        btn.BackColor = Color.DarkViolet;
                        btn.ForeColor = Color.White;
                        break;
                }

                // thêm button vào flow layout panel
                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lvBill.Items.Clear();
            flpBill.Controls.Clear();

            // lấy bill từ id table
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;

            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                totalPrice += item.TotalPrice;

                Button btn = new Button() { Width = 250, Height = 60};
                btn.Text = item.FoodName.ToString() + new string(' ', 45 - item.TotalPrice.ToString().Length - item.FoodName.ToString().Length) + item.TotalPrice.ToString() + "\n\n";
                btn.Text += "Price:" + new string(' ', 5) + item.Price.ToString();
                btn.Text += new string(' ', 45 - 22 - item.Price.ToString().Length - item.Count.ToString().Length) + "Count:" + new string(' ', 5) + item.Count.ToString();
                btn.Image = IconDAO.Instance.setIconButtonAndImage("icons8-bin-24.png");
                btn.Padding = new Padding(3, 0, 3, 0);
                btn.TextImageRelation = TextImageRelation.TextBeforeImage;
                btn.BackColor = Color.Ivory;

                // set event
                btn.Click += btnDeleteBill_Click;

                // lưu item vào button
                btn.Tag = item;

                flpBill.Controls.Add(btn);
                lvBill.Items.Add(lsvItem);

            }
            CultureInfo culture = new CultureInfo("vi-VN"); //en-US
            
            // setting lại luồng
            //Thread.CurrentThread.CurrentCulture = culture;
            //txbTotalPrice.Text = totalPrice.ToString("c");

            // hiện tổng tiền đơn vị _đ
            //txbTotalPrice.Text = totalPrice.ToString("c", culture);
            txbTax.Text = (totalPrice * 0.1).ToString("c", culture);
            int discount = (int)nmDiscount.Value;
            txbDiscount.Text = ((totalPrice / 100) * (double)discount).ToString("c", culture);
            txbTotal.Text = (totalPrice + (totalPrice * 0.1) - (totalPrice / 100) * (double)discount).ToString("c", culture);
        }

        void showFood(int id)
        {
            flpFood.Controls.Clear();

            // lấy bill từ id table
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);

        }

        void DeleteBill(string billName)
        {
            
        }

        // Load Table List vào Combo box Table hiện danh sách bàn
        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        #endregion

        #region Events

        // sự kiện phím tắt button pay Ctrl + C
        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // gọi event click check (pay)
            btnCheck_Click(this, new EventArgs());
        }

        // sự kiện phím tắt button add Ctrl + V
        private void addFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // gọi event click add
            btnAddFood_Click(this, new EventArgs());
        }

        // show bill khi click button
        private void btn_Click(object sender, EventArgs e)
        {
            // lấy table id
            int tableID = ((sender as Button).Tag as Table).ID;
            lvBill.Tag = (sender as Button).Tag;
            lbTable.Text = ((sender as Button).Tag as Table).Name;

            List<Food> foodList = FoodDAO.Instance.GetListFood();
            LoadFood(foodList);

            ShowBill(tableID);
        }

        // show food khi click category button
        private void btn_ClickCategory(object sender, EventArgs e)
        {
            // lấy category id
            int idCategory = ((sender as Button).Tag as Category).ID;
            idCategoryByClick = idCategory;
            LoadFoodListByCategoryID(idCategory);
        }

        private void BtnFood_Click(object sender, EventArgs e)
        {
            int idFood = ((sender as Button).Tag as Food).ID;
            idFoodByClick = idFood;
        }

        // xoá bill khi click button for flpBill
        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            // lấy table id
            string billName = ((sender as Button).Tag as Menu).FoodName;
            DeleteBill(billName);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // sự kiện nhấn personal trong menu Account Profile
        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //khởi tạo form Account Profile truyền vào LoginAccount
            frmAccountProfile f = new frmAccountProfile(LoginAccount);

            f.UpdateAccount += F_UpdateAccount;

            // show dialog
            f.ShowDialog();
        }

        // sửa tên hiển thị trên tool trip menu sau khi sự kiện update thành công
        private void F_UpdateAccount(object sender, AccountEvent e)
        {
            accountInformationToolStripMenuItem.Text = "Account profile (" + e.Acc.DisplayName + ")";
        }

        // sự kiện nhấn admin
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // khởi tạo form Admin
            frmAdmin f = new frmAdmin();

            f.loginAccount = loginAccount;

            // thêm các sự kiện cho insert, delete, update food thành công từ trang admin
            f.InsertFood += F_InsertFood;

            f.DeleteFood += F_DeleteFood;

            f.UpdateFood += F_UpdateFood;

            // thêm các sự kiện cho insert, delete, update category thành công từ trang admin
            f.InsertCategory += F_InsertCategory;

            f.DeleteCategory += F_DeleteCategory;

            f.UpdateCategory += F_UpdateCategory;

            // thêm các sự kiện cho insert, delete, update table thành công từ trang admin
            f.InsertTable += F_InsertTable;

            f.DeleteTable += F_DeleteTable;

            f.UpdateTable += F_UpdateTable;

            // hiện dialog
            f.ShowDialog();

        }

        private void F_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();

            if (lvBill.Tag != null)
            {
                ShowBill((lvBill.Tag as Table).ID);
            }
        }

        private void F_DeleteTable(object sender, EventArgs e)
        {
            LoadTable();

            if (lvBill.Tag != null)
            {
                ShowBill((lvBill.Tag as Table).ID);
            }
        }

        private void F_InsertTable(object sender, EventArgs e)
        {
            LoadTable();

            if (lvBill.Tag != null)
            {
                ShowBill((lvBill.Tag as Table).ID);
            }
        }

        private void F_UpdateCategory(object sender, EventArgs e)
        {
            LoadCategory();

            if (lvBill.Tag != null)
            {
                ShowBill((lvBill.Tag as Table).ID);
            }
        }

        private void F_DeleteCategory(object sender, EventArgs e)
        {
            LoadCategory();

            if (lvBill.Tag != null)
            {
                ShowBill((lvBill.Tag as Table).ID);
            }

            LoadTable();
        }

        private void F_InsertCategory(object sender, EventArgs e)
        {
            LoadCategory();

            if (lvBill.Tag != null)
            {
                ShowBill((lvBill.Tag as Table).ID);
            }
        }

        // load Food khi update thành công
        private void F_UpdateFood(object sender, EventArgs e)
        {
            //LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            LoadFoodListByCategoryID(((sender as Button).Tag as Category).ID);
            if (lvBill.Tag != null)
            {
                ShowBill((lvBill.Tag as Table).ID);
            }
        }

        // load Food khi delete thành công
        private void F_DeleteFood(object sender, EventArgs e)
        {
            //LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            LoadFoodListByCategoryID(((sender as Button).Tag as Category).ID);

            if (lvBill.Tag != null)
            {
                ShowBill((lvBill.Tag as Table).ID);
            }

            LoadTable();
        }

        // load Food khi insert thành công
        private void F_InsertFood(object sender, EventArgs e)
        {
            //LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            LoadFoodListByCategoryID(((sender as Button).Tag as Category).ID);

            if (lvBill.Tag != null)
            {
                ShowBill((lvBill.Tag as Table).ID);
            }

        }

        // sự kiện combobox Category thay đổi gọi hàm LoadFoodListByCategoryID()
        /*
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            // lấy id
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }
        */

        // sự kiện nhấn button Add food
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            // lấy table từ lvBill tag
            Table table = lvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Please choose table!");

                return;
            }
            
            // lấy id bill từ table id
            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);

            // lấy id Food từ Combo box Food đã chọn
            //int foodID = (cbFood.SelectedItem as Food).ID;
            int foodID = -1;
            if (idFoodByClick != -1)
            {
                foodID = idFoodByClick;
            }
            else
            {
                MessageBox.Show("Please chose a food!");
            }
            
            if (foodID >= 0)
            {
                // lấy số lượng từ numberic Food Count
                int count = (int)nmFoodCount.Value;

                if (idBill == -1)
                {
                    // thêm mới Bill
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.getMaxIDBill(), foodID, count);
                }
                else
                {
                    // Bill đã tồn tại
                    BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                }

                // show bill
                ShowBill(table.ID);

                // load table
                LoadTable();

                if(idCategoryByClick != -1)
                {
                    LoadFoodListByCategoryID(idCategoryByClick);
                }


            }
            
        }

        // Sự kiện cho thanh toán button check
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                // lấy table hiện tại
                Table table = lvBill.Tag as Table;
                if (table != null)
                {
                    // lấy id Bill từ id table
                    int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);

                    // lấy discount từ numeric Discount
                    int discount = (int)nmDiscount.Value;

                    string total = txbTotal.Text.Split(',')[0]; //txbTotalPrice.Text.Split(',')[0];
                    string[] totalTemp = total.Split('.');
                    total = "";
                    foreach (string t in totalTemp)
                    {
                        total += t;
                    }

                    double totalPrice = Convert.ToDouble(total);

                    double tax = totalPrice * 0.1;

                    List<BillInfo> list = BillInfoDAO.Instance.GetListBillInfo(idBill);

                    if (idBill != -1)
                    {
                        // tiến hành thanh toán
                        String mess = "The bill for the table {0}\n";
                        //mess += "Name\tQuantity\t\tPrice\n";

                        mess += "Discount:\t{1}\nTax:\t\t{3}\nTotal price:\t{2}";
                        if (MessageBox.Show(string.Format(mess, table.Name, discount, totalPrice, tax), "Payment", MessageBoxButtons.OKCancel) ==
                            DialogResult.OK)
                        {
                            // gọi CheckOut
                            BillDAO.Instance.CheckOut(idBill, discount, (float)totalPrice);
                            ShowBill(table.ID);

                            LoadTable();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please chose table!");
                }
            }
            catch (Exception) { }
            
        }

        // sự kiện button Switch Table
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            // id Table đang chọn
            int id1 = (lvBill.Tag as Table).ID;

            // lấy id dc chọn từ combo box
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;

            if(MessageBox.Show(string.Format("Do you want to switch table {0} to table {1}", (lvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Message", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                // chuyển bàn
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }

            
        }

        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            flpTable.Controls.Clear();

            //lấy data
            List<Table> tableList = TableDAO.Instance.SearchForLoadTable(txbSearchTableName.Text);

            foreach (Table item in tableList)
            {
                // tạo button width và height
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status; // Environment.NewLine = \n
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.Font = new Font(btn.Font, FontStyle.Bold);

                // set event
                btn.Click += btn_Click;

                // lưu item vào button
                btn.Tag = item;

                // set màu cho status
                switch (item.Status)
                {
                    case "Empty":

                        // button Add Food
                        btn.Image = IconDAO.Instance.setIconButtonAndImage("icons8-table-47.png");
                        btn.ImageAlign = ContentAlignment.TopCenter;
                        btn.BackColor = Color.LightYellow;
                        break;
                    default:
                        btn.Image = IconDAO.Instance.setIconButtonAndImage("icons8-table-49.png");
                        //btn.Image = Properties.Resources.icons8_table_49;
                        btn.ImageAlign = ContentAlignment.TopCenter;
                        btn.BackColor = Color.DarkViolet;
                        btn.ForeColor = Color.White;
                        break;
                }

                // thêm button vào flow layout panel
                flpTable.Controls.Add(btn);
            }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            //lấy data
            List<Food> foodList = FoodDAO.Instance.SearchForLoadFood(txbSearchFoodName.Text);
            LoadFood(foodList);
        }

        private void btnAllFood_Click(object sender, EventArgs e)
        {
            //lấy data
            List<Food> foodList = FoodDAO.Instance.GetListFood();
            LoadFood(foodList);

        }



        #endregion

       
    }
}
