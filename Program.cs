using Proyecto_Practica01_.Domain;
using Proyecto_Practica01_.Services;

BillDetailService bds = new BillDetailService();
BillService bs = new BillService();

Console.WriteLine("¿Que desea hacer? \n" +
    "1- Ver todas las facturas\n" +
    "2- Ver los detalles de facturas\n" +
    "3- Buscar una única factura\n" +
    "4- Eliminar una factura\n" +
    "5-Guardar una factura nueva");

int choice = Convert.ToInt32(Console.ReadLine());

if(choice == 1)
{

List<Bill> list = bs.GetAllBills();

if (list.Count > 0)
    foreach (Bill bill in list)
        Console.WriteLine(bill);
else
    Console.WriteLine("No hay facturas");

}
if (choice == 2)

{
    
    List<BillDetail> listD = bds.GetAllBillDetails();

    if (listD.Count > 0)
        foreach (BillDetail bd in listD)
            Console.WriteLine(bd);
    else
        Console.WriteLine("No hay detalles");
}

if (choice == 3)
{
    Console.WriteLine("Ingrese el id de la factura a buscar:");
    int id = Convert.ToInt32(Console.ReadLine());

    if(id == 0)
    {
        Console.WriteLine("No se encontró la factura");
    }
    else
    {
        Bill bill = bs.GetBill(id);
        if (bill == null)
        {
            Console.WriteLine("No se encontró la factura");
        }
        else
            Console.WriteLine(bill.ToString());
            
    }
}
if (choice == 4)
{
    Console.WriteLine("Ingrese el id de la factura a eliminar:");
    int id = Convert.ToInt32(Console.ReadLine());

    if (id == 0)
    {
        Console.WriteLine("No se encontró la factura");
    }
    else
    {
        bs.DeleteBill(id);
        Console.WriteLine("Se ha eliminado correctamente");
    }
}
if (choice == 5)
{

    Bill bill = new Bill();

    Console.WriteLine("Ingrese el numero de la factura a guardar:");
    bill.Id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Ingrese la fecha de la factura a guardar:");
    bill.Date= Convert.ToDateTime(Console.ReadLine());

    Console.WriteLine("Ingrese el id de la forma de pago de la factura a guardar:");
    bill.IdpaymentForm = Convert.ToInt32(Console.ReadLine());

    bs.SaveBill(bill);
}
if (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5)
{
    Console.WriteLine("Opción inválida");
}