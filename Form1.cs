using FoodDelivery.Controller;
using FoodDelivery.Model;
using FoodDelivery.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class Form1 : Form
    {

        DisheTypeController dishTypeController = new DisheTypeController();
        DisheController disheController = new DisheController();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<DishType> allDishType = dishTypeController.GetAllDishesType();
            cmbType.DataSource = allDishType;   
            cmbType.DisplayMember= "Name";  
            cmbType.ValueMember = "Id";

            btnSelectAll_Click(sender, e);
        }
        private void LoadRecord(Dish dish)
        {
            txtId.BackColor = Color.White;
            txtId.Text = dish.Id.ToString();
            txtName.Text = dish.Name;
            txtPrice.Text = dish.Price.ToString();
            txtWeight.Text = dish.Weight.ToString();    
            cmbType.Text = dish.DishTypes.Name;
        }
        private void ClearScreen()
        {
            txtId.BackColor = Color.White;
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtWeight.Clear();
            cmbType.Text = "";
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Dish> allDish = disheController.GetAll();
            lstBoxOpisanie.Items.Clear();
            foreach (var item in allDish)
            {
                lstBoxOpisanie.Items.Add($"{item.Id}. {item.Type} - {item.Name} - Цена: {item.Price}  Грамаж:{item.Weight} ");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txtName.Focus();
                return;
            }
            Dish newDish = new Dish();
            newDish.Weight = double.Parse(txtWeight.Text);
            newDish.Name = txtName.Text;
            newDish.Price = double.Parse(txtPrice.Text);
            newDish.DishTypesId = (int)cmbType.SelectedValue;

            disheController.Create(newDish);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            btnSelectAll_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            //Ако няма намерен запис търсим по Id и визуализираме на екрана
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Dish findedDog = disheController.Get(findId);
                if (findedDog == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                LoadRecord(findedDog);
            }
            else //Ако има намерен вече запис променяме по полетата
            {
                Dish updatedDish = new Dish();
                updatedDish.Name = txtName.Text;
                updatedDish.Weight = double.Parse(txtWeight.Text);
                
                updatedDish.DishTypesId= (int)cmbType.SelectedValue;

                disheController.Update(findId, updatedDish);
            }
            btnSelectAll_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Dish findDish = disheController.Get(findId);
            if (findDish == null)
            {
                MessageBox.Show("Нама такъв запис в базата данни!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(findDish);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис N" + findId + "?", "PROMPT", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                disheController.Delete(findId);
            }
            btnSelectAll_Click(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Dish findedDish = disheController.Get(findId);
            if (findedDish == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(findedDish);
            btnSelectAll_Click(sender, e);

        }
    }
}
