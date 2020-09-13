namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
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
                       publishingHouseId = c.Int(nullable: false, identity: true),
                       phNo=c.String(nullable:false, name: "出版社编号"),
                       phName = c.String(maxLength: 250),
                       phAdress = c.String()
                   })
                   .PrimaryKey(t => t.publishingHouseId);

            CreateTable(
                "dbo.Lms_Books",
                c => new
                {
                    bookId = c.Int(nullable: false, identity: true),
                    bookNo = c.String(maxLength: 250),
                    publishingHouseId = c.String(),
                    bookTypeId = c.String(),
                    bookName = c.String(),
                    Author =c.String(),
                    price=c.Double(),
                    totalPages=c.Int(),
                    TotalInventory=c.Int(),
                    ExistingInventory=c.Int(),
                    StorageTime= c.DateTime(nullable: false),    //这里应该是不考虑每本的情况
                    loansNumber=c.Int()
                })
                .PrimaryKey(t => t.bookId)
                .Index(t => t.bookTypeId)
                .Index(t => t.publishingHouseId);
        }
        
        public override void Down()
        {
        }
    }
}
