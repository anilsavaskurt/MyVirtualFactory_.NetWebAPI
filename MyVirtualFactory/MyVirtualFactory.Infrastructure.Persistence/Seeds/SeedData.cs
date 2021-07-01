using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Domain.Entities;

namespace MyVirtualFactory.Infrastructure.Persistence.Seeds
{
    public class SeedData
    {
        public static async Task SeedAsync(IOperationRepositoryAsync operationRepository,
            ICustomerRepositoryAsync customerRepository, IOrderItemRepositoryAsync orderItemRepository,
            IOrderRepositoryAsync orderRepository, IProductRepositoryAsync productRepository,
            ISubProductTreeRepositoryAsync subProductRepository, IUserRepositoryAsync userRepository,
            IWorkCenterRepositoryAsync workCenterRepository, IWorkCenterOperationRepositoryAsync workCenterOperationRepository)
        {
         

            //CUSTOMER 
          //  Customer customer = new Customer()
          //  {
          //      LastName = "Ozat",
          //      Name = "Umut",
          //      CustomerUserId = "customer1"
          //  };
          //  await customerRepository.AddAsync(customer);

          //  User user = new User() { 
          //  Name="Anıl",
          //  LastName="Savaskurt",
          //  StaffUserId = "staff1"
          //  };
          //  await userRepository.AddAsync(user);

          //  // PRODUCTS
          //  Product product = new Product()
          //  {
          //      IsSalable = true,
          //      Name = "Normal Car",
          //      ProductType = Domain.Enums.ProductType.Car,
          //  };


          //  Product product1 = new Product()
          //  {
          //      IsSalable = false,
          //      Name = "Car Plastics",
          //      ProductType = Domain.Enums.ProductType.Plastic
          //  };



          //  Product product2 = new Product()
          //  {
          //      IsSalable = false,
          //      Name = "Bonnet",
          //      ProductType = Domain.Enums.ProductType.Metal
          //  };




          //  await productRepository.AddAsync(product);
          //  await productRepository.AddAsync(product1);
          //  await productRepository.AddAsync(product2);

          //  //SUBPRODUCTS
          //  SubProductTree subProductTree = new SubProductTree()
          //  {
          //      SubProductId= product1.Id,
          //   //   SubProduct = product1,
          //      ProductId= product.Id,
          // //     Product = product,
          //      ProduceAmount = 1
          //  };
          //  await subProductRepository.AddAsync(subProductTree);

          //  Order order = new Order()
          //  {
          //      OrderDate = DateTime.Now,
          //      OrderDeadLineDate = DateTime.Now,
          //      CustomerId=customer.Id
          //    //  Customer = customer
          //  };
          //  Order order1 = new Order()
          //  {
          //      OrderDate = DateTime.Now,
          //      OrderDeadLineDate = DateTime.Now,
          //      CustomerId = customer.Id
          //  //    Customer = customer
          //  };
          //  await orderRepository.AddAsync(order);
          //  await orderRepository.AddAsync(order1);




          ////  Kullanıcnın sepet bilgisi
          ////  Birden fazla ürün göstermek için
          //  OrderItem orderItem = new OrderItem()
          //  {
          //      OrderId=order.Id,
          //      ProductId=product.Id,
          //    //  Order = order,
          //    //  Product = product,
          //      Amount = 1
          //  };
          //  await orderItemRepository.AddAsync(orderItem);


          //  //Bir ürün üretilmesi için olan işlem listesi
          //  // ör araba -> metal bükülmesi, plastik aksam üretilmesi, montaj
          //  Operation operation = new Operation()
          //  {
          //      OperationName = "Bending metal",
          //      OperationProductType = Domain.Enums.ProductType.Metal
          //  };
          //  Operation operation1 = new Operation()
          //  {
          //      OperationName = "Painting Car Body Metal",
          //      OperationProductType = Domain.Enums.ProductType.Metal
          //  };

          //  Operation operation2 = new Operation()
          //  {
          //      OperationName = "Combine Pvc",
          //      OperationProductType = Domain.Enums.ProductType.Plastic
          //  };

          //  Operation operation3 = new Operation()
          //  {
          //      OperationName = "Shape plastic",
          //      OperationProductType = Domain.Enums.ProductType.Plastic
          //  };
          //  Operation operation4 = new Operation()
          //  {
          //      OperationName = "Combine Car body",
          //      OperationProductType = Domain.Enums.ProductType.Car
          //  };
          //  Operation operation5 = new Operation()
          //  {
          //      OperationName = "Combine Car Plastics",
          //      OperationProductType = Domain.Enums.ProductType.Car
          //  };
          //  await operationRepository.AddAsync(operation);
          //  await operationRepository.AddAsync(operation1);
          //  await operationRepository.AddAsync(operation2);
          //  await operationRepository.AddAsync(operation3);
          //  await operationRepository.AddAsync(operation4);
          //  await operationRepository.AddAsync(operation5);


          //  // WORK CENTERS
          //  WorkCenter workCenter = new WorkCenter()
          //  {
          //      WorkCenterName = "Bending Metal Work Center",
          //      IsActive = true
          //  };
          //  WorkCenter workCenter1 = new WorkCenter()
          //  {
          //      WorkCenterName = "Painting Car Body Metal",
          //      IsActive = true
          //  };
          //  WorkCenter workCenter2 = new WorkCenter()
          //  {
          //      WorkCenterName = "Combine Pvc",
          //      IsActive = true
          //  };
          //  WorkCenter workCenter3 = new WorkCenter()
          //  {
          //      WorkCenterName = "Shape plastic",
          //      IsActive = true
          //  };

          //  WorkCenter workCenter4 = new WorkCenter()
          //  {
          //      WorkCenterName = "Combine Car Body",
          //      IsActive = false
          //  };

          //  WorkCenter workCenter5 = new WorkCenter()
          //  {
          //      WorkCenterName = "Combine Car Plastics",
          //      IsActive = false
          //  };
          //  await workCenterRepository.AddAsync(workCenter);
          //  await workCenterRepository.AddAsync(workCenter1);
          //  await workCenterRepository.AddAsync(workCenter2);
          //  await workCenterRepository.AddAsync(workCenter3);
          //  await workCenterRepository.AddAsync(workCenter4);
          //  await workCenterRepository.AddAsync(workCenter5);

            //WORK CENTERS OPERATIONS
            // Metal Bükme
            //WorkCenterOperation workCenterOperation = new WorkCenterOperation()
            //{
            //    OperationId=
            //   // Operation = operation,
            //   // WorkCenter = workCenter,
            //    Speed = 5
            //};
            //WorkCenterOperation workCenterOperation1 = new WorkCenterOperation()
            //{

            //    Operation = operation1,
            //    WorkCenter = workCenter1,
            //    Speed = 5
            //};
            //// Metal Boyama
            //WorkCenterOperation workCenterOperation2 = new WorkCenterOperation()
            //{

            //    Operation = operation2,
            //    WorkCenter = workCenter2,
            //    Speed = 5
            //};
            //// PVC Birleştirip Plastik üretme
            //WorkCenterOperation workCenterOperation3 = new WorkCenterOperation()
            //{

            //    Operation = operation3,
            //    WorkCenter = workCenter3,
            //    Speed = 5
            //};
            //// araç kaportası birleştirilmesi
            //WorkCenterOperation workCenterOperation4 = new WorkCenterOperation()
            //{

            //    Operation = operation4,
            //    WorkCenter = workCenter4,
            //    Speed = 5
            //};

            //// araç plastiklerinin birleştirilmesi
            //WorkCenterOperation workCenterOperation5 = new WorkCenterOperation()
            //{

            //    Operation = operation5,
            //    WorkCenter = workCenter5,
            //    Speed = 5
            //};

            //await workCenterOperationRepository.AddAsync(workCenterOperation);
            //await workCenterOperationRepository.AddAsync(workCenterOperation1);
            //await workCenterOperationRepository.AddAsync(workCenterOperation2);
            //await workCenterOperationRepository.AddAsync(workCenterOperation3);
            //await workCenterOperationRepository.AddAsync(workCenterOperation4);
            //await workCenterOperationRepository.AddAsync(workCenterOperation5);
        }
    }
}
