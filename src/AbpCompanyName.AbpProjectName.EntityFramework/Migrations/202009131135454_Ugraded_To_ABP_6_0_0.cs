namespace AbpCompanyName.AbpProjectName.Migrations
{
    using Abp.Extensions;
    using Abp.Threading.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    
    public partial class Ugraded_To_ABP_6_0_0 : DbMigration
    {
        //Library Management System
        //https://www.cnblogs.com/wkfvawl/p/11052660.html
        public override void Up()
        {
            CreateTable(
                   "dbo.Lms_PublishingHouse",
                   c => new
                   {
                       PublishingHouseId = c.Int(nullable: false, identity: true),
                       PhNo=c.String(nullable:false, name: "出版社编号"),
                       PhName = c.String(maxLength: 250,name: "出版社名称"),
                       PhAdress = c.String(name: "出版社地址")
                   })
                   .PrimaryKey(t => t.PublishingHouseId);

            CreateTable(
                "dbo.Lms_Books",
                c => new
                {
                    BookId = c.Int(nullable: false, identity: true),
                    BookNo = c.String(maxLength: 250),
                    PublishingHouseId = c.String(),
                    BookTypeId = c.String(),
                    BookName = c.String(),
                    Author =c.String(),
                    Price=c.Double(),
                    TotalPages=c.Int(),
                    TotalInventory=c.Int(),
                    ExistingInventory=c.Int(),
                    StorageTime= c.DateTime(nullable: false),    //这里应该是不考虑每本的情况
                    LoansNumber=c.Int()
                })
                .PrimaryKey(t => t.BookId)
                .Index(t => t.BookTypeId)
                .Index(t => t.PublishingHouseId);

            CreateTable("dbo.Lms_BookType",
                c => new
                {
                    BookTypeId = c.Int(nullable: false, identity: true),
                    BookTypeName = c.String(),
                    LibraryNo = c.String()
                }).PrimaryKey(t => t.BookTypeId);

            CreateTable("dbo.Lms_Readers",
               c => new
               {
                   ReaderId = c.Int(nullable: false, identity: true),
                   ReaderTypeId = c.Int(),
                   LibraryId = c.String(),
                   ReaderName=c.String(),
                   Gender=c.String(),
                   BirthDateTime=c.DateTime(),
                   IdentityNumber=c.String(),
                   BooksBorrowedNumber=c.Int(),
                   ReportLoss=c.Int(),
                   BooksBorrowedAlready=c.Int(),
                   UnpaidFine=c.Decimal()
               })
               .PrimaryKey(t => t.ReaderId)
               .Index(t=>t.ReaderTypeId)
               .Index(t=>t.LibraryId);

            CreateTable("dbo.Lms_Readers",
              c => new
              {
                  ReaderTypeId = c.Int(nullable: false, identity: true),
                  ReaderTypeName = c.String(),
                  BooksNumberAllowed = c.Int(),
                  BorrowedDays = c.Int(),
                  RenewableDays = c.Int()
              })
              .PrimaryKey(t => t.ReaderTypeId);

        }

        public override void Down()
        {
        }
    }
}
