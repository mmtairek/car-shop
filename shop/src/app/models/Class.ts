export class Car{
    public id:number;
    public model:string;
    public make:string;
    public year:number;
    public warehouse:string;
    public location:string;
    public price?:number;
    public currency:string;
    public addedDate?:Date;
    public isLicensed:boolean;
    public isAddedToCart:boolean;

    constructor(id:number, model:string, make:string, year:number, warehouse:string,
        location:string, price:number,currency:string, addedDate:Date, 
        isLicensed:boolean, isAddedToCart:boolean){
        this.id = id;
        this.model = model;
        this.make = make;
        this.year = year;
        this.warehouse = warehouse;
        this.location  = location;
        this.price = price;
        this.currency = currency;
        this.addedDate = addedDate;
        this.isLicensed = isLicensed;
        this.isAddedToCart = false;
    }
}