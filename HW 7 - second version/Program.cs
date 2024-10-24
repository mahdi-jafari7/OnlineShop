
using HW_7___second_version;
using HW_7___second_version.Database;
using HW_7___second_version.Enums;
using HW_7___second_version.Services;


AuthService authService = new AuthService();
ShoppingService shoppingService = new ShoppingService();

void enter()
{
    Console.WriteLine("Welcome to my Online shop!");

    Console.WriteLine("Do you have an account? (yes/no)");
    string hasAccount = Console.ReadLine();
    User currentUser = null;

    if (hasAccount.ToLower() == "no")
    {
        Console.Clear();
        Console.WriteLine("******************");
        Console.WriteLine("Register a new account:");
        Console.WriteLine("******************");
        Console.Write("Plase enter your Firstname: ");
        string firstname = Console.ReadLine();
        Console.Write("please enter your lastname: ");
        string lastname = Console.ReadLine();
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        Console.WriteLine("Enter your role ( custumer(0) - Admin(1)) ");
        int role_register = int.Parse(Console.ReadLine());

        authService.Register(username, password, (RoleEnum)role_register);
    }

    while (currentUser == null)
    {
        Console.Clear();
        Console.WriteLine("### Login Form ###");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        currentUser = authService.Login(username, password);
        if (currentUser != null)
        {
            shoppingMethode();
        }

    }
}
enter();

void shoppingMethode()
{
    bool shopping = true;
    bool iscontinue = true;
    while (iscontinue)
    {
        if (Store.CurrentUser.Role == RoleEnum.Admin)
        {
            Console.WriteLine("you are an Admin! Do you want to use Online Shop Or use Admin pannel?");
            Console.WriteLine("1. Online Shop");
            Console.WriteLine("2. Admin pannel");
            if (int.Parse(Console.ReadLine()) == 2)
            {
                Console.Clear();
                AdminMenu();
            }
        }
        while (shopping)
        {
            Store.ShowProducts();
            Console.Write("Please Enter the product ID to add to cart (or press 0 to finalize order): ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                shoppingService.Checkout();
                shopping = false;
            }
            else
            {
                int productId = input;
                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                shoppingService.AddToCart(productId, quantity);
            }

        }
        Console.WriteLine("Do you want to see your order history? (yes/no)");
        if (Console.ReadLine().ToLower() == "yes")
        {
            shoppingService.ShowOrderHistory();
            Console.WriteLine("new Order (press 2) \nSignout(press3)");
            int neworder = int.Parse(Console.ReadLine());
            if (neworder == 2)
            {
                Store.CurrentUser.NowShoppingList.card.Clear();
                iscontinue = true;
                shopping = true;
            }
            else if (neworder == 3)
            {
                {

                    Store.CurrentUser = null;
                    enter();
                    break;
                    iscontinue = false;
                }
            }

        }
    }

    void AdminMenu()
    {
        Console.WriteLine($"********* Welcome to Admin pannel{Store.CurrentUser.FirstName} *********");

        while (true)
        {
            AdminServices adminServices = new AdminServices();


            Console.WriteLine("1. Confirm Orders ");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Edit Product Inventory");
            Console.WriteLine("4. remove product");
            Console.WriteLine("5. View All Orders");
            Console.WriteLine("6. Sign Out");

            Console.WriteLine("Choose an option: ");
            int Admin_menu_option = int.Parse(Console.ReadLine());

            switch (Admin_menu_option)
            {
                case 1:
                    adminServices.CompleteOrder();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("**** Add Product ****");
                    Console.WriteLine("Enter Product's Name:");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Enter Product's Price: ");
                    decimal productPrice = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("enter Product's inventory: ");
                    int productInventory = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter Product's Catagory: (laptop : 0 , smartphone : 1 , airpod :2  ");
                    int productCatagory = int.Parse(Console.ReadLine());
                    adminServices.AddProduct(productName, (Catagoryenum)productCatagory, productPrice, productInventory);
                    break;
                case 3:
                    Console.Clear();

                    Store.ShowProducts();
                    Console.WriteLine("which Product do you want edit? enter ID");
                    int change_id = int.Parse(Console.ReadLine());
                    Console.WriteLine($"You selected {Store.Products[change_id]}");
                    Console.WriteLine("enter a new amount for inventory: ");
                    int new_amount = int.Parse(Console.ReadLine());
                    adminServices.ChangeInventory(change_id, new_amount);
                    break;
                case 4:
                    Console.Clear();
                    Store.ShowProducts();
                    Console.WriteLine("Which Product do you want to remove?");
                    int idRemove = int.Parse(Console.ReadLine());
                    adminServices.RemoveProduct(idRemove);
                    break;
                case 5:
                    Console.Clear();
                    adminServices.ShowAllOrders();
                    break;
                case 6:
                    Store.CurrentUser = null;
                    enter();
                    break;

            }

        }
    }
}