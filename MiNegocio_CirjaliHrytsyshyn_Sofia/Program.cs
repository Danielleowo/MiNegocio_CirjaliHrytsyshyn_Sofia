namespace HealthyProducts;

using System;
class Program
{
    static void Main(string[] args)
    {
        //==============================================================
        // Healthy Products: Ventas y caja
        //==============================================================


        // Datos de la caja

        int operacionesRealizadas = 0;
        Double recaudacion = 0;
        Double operacionMasCara = 0;
        string clienteOperacionMasCara = "";

        int opcionPrincipal = 0;

        //===================================================================
        // MENU DE OPCIONES PRINCIPAL
        //===================================================================

        do
        {
            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("           HEALTHY PRODUCTS           ");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Registrar una nueva venta");
            Console.WriteLine("2. Consultar la caja registradora");
            Console.WriteLine("0. Salir");
            Console.Write("Selecione una opcion, porfavor: ");

            if (!int.TryParse(Console.ReadLine(), out opcionPrincipal))
            {
                Console.WriteLine("Opcion incorrecta. Introduce un numero valido.");
                continue;
            }
            if (opcionPrincipal == 1)
            {
                //===================================================
                // Parte 1. Datos del cliente
                //===================================================

                Console.WriteLine();
                Console.WriteLine("--- Nueva Venta ---");

                string nombreCliente;

                do
                {
                    Console.WriteLine("Nombre del cliente: ");
                    nombreCliente = Console.ReadLine() ?? "";
                    if (nombreCliente.Trim() == "")
                    {
                        Console.WriteLine("El nombre no puede estar vacio");
                    }
                }
                while (nombreCliente.Trim() == "");

                //============================================================
                // Parte 2. Producto principal
                //============================================================

                int opcionProducto;
                String producto = "";
                double precioBase = 0;

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("--- PRODUCTO PRINCIPAL ---");
                    Console.WriteLine("1. Pack de Frutas Frescas: 8,00 euros");
                    Console.WriteLine("2. Cesta de Verduras Con Envase Ecologico: 12,00 euros");
                    Console.WriteLine("3. SuperMix (Frutos secos y semillas): 15,00 euros");

                    if (!int.TryParse(Console.ReadLine(), out opcionProducto))
                    {
                        opcionProducto = 0;
                    }

                    if (opcionProducto < 1 || opcionProducto > 3)
                    {
                        Console.WriteLine("Debes seleccionar una opcion entre 1 y 3.");
                    }
                }
                while (opcionProducto < 1 || opcionProducto > 3);

                if (opcionProducto == 1)
                {
                    producto = "Pack de Frutas Frescas";
                    precioBase = 8.00;
                } 
                else if (opcionProducto == 2)
                {
                    producto = "Cesta de Verduras Con Envase Ecologico";
                    precioBase = 12.00;
                }
                else
                {
                    producto = "SuperMix";
                    precioBase = 15.00;
                }
                
                //====================================================================
                // Parte 3. Productos Adicionales para escoger
                //====================================================================

                bool tieneInfusion = false;
                bool tieneFrutosSecos = false;
                bool tieneMiel = false;
                bool tieneAceite = false;

                int opcionExtra;
                int cantidadExtras = 0;
                double precioExtras = 0;

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("--- PRODUCTOS ADICIONALES PARA ESCOGER ---");
                    Console.WriteLine("Todos los productos incluyen garania de origen ECO");
                    Console.WriteLine("1. Infusion Detox (20 bolsitas): 2,50 euros");
                    Console.WriteLine("2. SnackBar Energetica BIO: 3,00 euros");
                    Console.WriteLine("3. Miel Pura Artesanal (500g): 4,00 euros");
                    Console.WriteLine("4. Aceite de Oliva Virgen Extra (250ml): 5,00 euros");
                    Console.WriteLine("0. Terminar seleccion");
                    Console.WriteLine();
                    Console.WriteLine("Extras selecciones: " + cantidadExtras);
                    Console.WriteLine("Precio actual provisional: " + (precioBase + precioExtras).ToString("F2") + " euros");

                    Console.Write("Selecciona una opcion: ");
                    if (!int.TryParse(Console.ReadLine(), out opcionExtra))
                    {
                        opcionExtra = -1;
                    }

                    if (opcionExtra == 1)
                    {
                        if (tieneInfusion)
                        {
                            Console.WriteLine("Ya has añadido la Infusion Detox.");
                        }
                        else
                        {
                            tieneInfusion = true;
                            precioExtras += 2.50;
                            cantidadExtras++;
                            Console.WriteLine("Infusion Detox añadida.");
                        }
                    }
                    else if (opcionExtra == 2)
                    {
                        if (tieneFrutosSecos)
                        {
                            Console.WriteLine("Ya has añadido la snackBar energetica BIO.");
                        }
                        else
                        {
                            tieneFrutosSecos = true;
                            precioExtras += 3.00;
                            cantidadExtras++;
                            Console.WriteLine("SnackBar Energetica BIO añadida.");
                        }
                    }
                    else if (opcionExtra == 3)
                    {
                        if (tieneMiel)
                        {
                            Console.WriteLine("Ta has añadido la Miel Pura Artesanal.");
                        }
                        else
                        {
                            tieneMiel = true;
                            precioExtras += 4.00;
                            cantidadExtras++;
                            Console.WriteLine("Miel Pura artesanal añadida.");
                        }
                    } 
                    else if (opcionExtra == 4)
                    {
                        if (tieneAceite)
                        {
                            Console.WriteLine("Ya has añadido el aceite de Oliva Virgen Extra.");
                        }
                        else
                        {
                            tieneAceite = true;
                            precioExtras += 5.00;
                            cantidadExtras++;
                            Console.WriteLine("Aceite de Oliva Virgen Extra añadido.");
                        }
                    }
                    else if (opcionExtra != 0)
                    {
                        Console.WriteLine("Debes seleccionar una opcion ente 0 y 4.");
                    }
                } 
                while (opcionExtra != 0);

                //===================================================
                // Parte 4. Forma de entrega especifica
                //===================================================

                int opcionEntrega;
                string formaEntrega = "";
                string direccion = "";
                double suplementoEnvio = 0;

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("--- FORMA DE ENTREGA ---");
                    Console.WriteLine("1. Recogida en tienda: Sin suplemento");
                    Console.WriteLine("2. Envio a domicilio: 3,00 euros ");
                    Console.Write("Selecciona una Opcion: ");
                    
                    if (!int.TryParse(Console.ReadLine(), out opcionEntrega))
                    {
                        opcionEntrega = 0;
                    }

                    if (opcionEntrega < 1 || opcionEntrega > 2)
                    {
                        Console.WriteLine("Debes seleccionar la opcion 1 o 2.");
                    }
                }
                while (opcionEntrega < 1 || opcionEntrega > 2);

                if (opcionEntrega == 1)
                {
                    formaEntrega = "Recogida en tienda";
                }
                else
                {
                    formaEntrega = "Envio a domicilio";
                    suplementoEnvio = 3.00;

                    do
                    {
                        Console.Write("Direccion de entrega: ");
                        direccion = Console.ReadLine() ?? "";

                        if (direccion.Trim() == "")
                        {
                            Console.WriteLine("La direccion no puede estar vacia.");
                        }
                    }
                    while (direccion.Trim() == "");
                }

                //=========================================================================
                // Parte 5. Calculo del importe y descuento
                //=========================================================================
            
                double subtotalProducto = precioBase + precioExtras;
                double descuento = 0;

                if (subtotalProducto >= 20.00)
                {
                    descuento = subtotalProducto * 0.15;
                }
                double totalVenta = subtotalProducto - descuento + suplementoEnvio;

                Console.WriteLine();
                Console.WriteLine("--- RESUMEN DEL IMPORTE ---");
                Console.WriteLine("Producto y extras: " + subtotalProducto.ToString("F2") + " euros");
                Console.WriteLine("Descuento aplicado: -" + descuento.ToString("F2") + " euros");
                Console.WriteLine("Suplemento de envio: " + suplementoEnvio.ToString("F2") + " euros");
                Console.WriteLine("TOTAL A PAGAR: " + totalVenta.ToString("F2") + " euros");

                //================================================================================
                // Parte 6. Cobro de la venta
                //================================================================================

                double importeEntregado = 0;

                do
                {
                    Console.Write("Importe entregado por el cliente: ");
                    if (!double.TryParse(Console.ReadLine(), out importeEntregado))
                    {
                        importeEntregado = 0;
                    }

                    if (importeEntregado < totalVenta)
                    {
                        Console.WriteLine("Importe isnuficiente. Debes introducir de nuevo el importe completo entregado.");
                    }
                }
                while (importeEntregado < totalVenta);

                double cambio = importeEntregado - totalVenta;

                //==============================================================================================
                // Parte 7. Actualizacion de la caja registradora
                //==============================================================================================

                operacionesRealizadas++;
                recaudacion += totalVenta;

                if (operacionesRealizadas == 1 || totalVenta > operacionMasCara)
                {
                    operacionMasCara = totalVenta;
                    clienteOperacionMasCara = nombreCliente;
                }

                //==============================================================================================
                // Parte 8. Ticket de la venta
                //==============================================================================================

                Console.WriteLine();
                Console.WriteLine("======================================");
                Console.WriteLine("       HEALTHY PRODUCTS - TICKET      ");
                Console.WriteLine("======================================");
                Console.WriteLine("Operacion numero: " + operacionesRealizadas);
                Console.WriteLine("Cliente: " + nombreCliente);
                Console.WriteLine("Producto principal: " + producto);
                Console.WriteLine("Extras adicionales:");

                if (cantidadExtras == 0)
                {
                    Console.WriteLine(" Ninguno");
                }
                else
                {
                    if (tieneInfusion) Console.WriteLine("  - Infusion Detox");
                    if (tieneFrutosSecos) Console.WriteLine("  - SnackBAr Energetica BIO");
                    if (tieneMiel) Console.WriteLine("  - Miel Pura Artesanal");
                    if (tieneAceite) Console.WriteLine("  - Aceite de Oliva Virgen Extra");
                }
                
                Console.WriteLine("Entrega: " + formaEntrega);
                if (opcionEntrega == 2)
                {
                    Console.WriteLine("Direccion: " + direccion);
                }

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Precio base:       " + precioBase.ToString("F2") + " euros");
                Console.WriteLine("Extras:            " + precioExtras.ToString("F2") + " euros");
                Console.WriteLine("Subtotal producto: " + subtotalProducto.ToString("F2") + " euros");
                Console.WriteLine("Descuento:        -" + descuento.ToString("F2") + " euros");
                Console.WriteLine("Suplemento envio:  " + suplementoEnvio.ToString("F2") + " euros");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("TOTAL:             " + totalVenta.ToString("F2") + " euros");
                Console.WriteLine("Entregado:         " + importeEntregado.ToString("F2") + " euros");
                Console.WriteLine("Cambio:            " + cambio.ToString("F2") + " euros");
                Console.WriteLine("==================================================");
                Console.WriteLine("¡Gracias por comprar en HealthyProducts!");
            }
            else if (opcionPrincipal == 2)
            {
                //================================================================
                // CAJA REGISTRADORA DEL DIA
                //================================================================

                Console.WriteLine();
                Console.WriteLine("===========================================");
                Console.WriteLine("         CAJA REGISTRADORA DEL DIA         ");
                Console.WriteLine("===========================================");

                if (operacionesRealizadas == 0)
                {
                    Console.WriteLine("Todavia no se aregistrado ninguna venta.");
                }
                else
                {
                    double importeMedio = recaudacion / operacionesRealizadas;

                    Console.WriteLine("Operaciones realizadas: " + operacionesRealizadas);
                    Console.WriteLine("Recaudacion total: " + recaudacion.ToString("F2") + " euros");
                    Console.WriteLine("Importe medio: " + importeMedio.ToString("F2") + " euros");
                    Console.WriteLine("Operacion mas cara: " + operacionMasCara.ToString("F2") + " euros");
                    Console.WriteLine("Cliente de la operacion mas cara: " + clienteOperacionMasCara);
                }
            }
            else if (opcionPrincipal == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Cerrando HealthyProducts...");
                Console.WriteLine("Operaciones realizadas: " + operacionesRealizadas);
                Console.WriteLine("Recaudacion final: " + recaudacion.ToString("F2") + " euros");
                Console.WriteLine("¡Hasta pronto!");
            }
            else
            {
                Console.WriteLine("Opcion incorrecta. Selecciona 1, 2 o 0.");
            }
        }
        while (opcionPrincipal != 0);
    }
}