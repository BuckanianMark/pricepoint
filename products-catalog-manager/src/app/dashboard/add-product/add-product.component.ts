import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductService } from '../product.service';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/Models/Product';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit{
  protected productForm!:FormGroup;
  protected formTitle = 'Add';
  PicturePreview!:ArrayBuffer |string |null;
  pictureFile = '';
  productPicturePath = '';
  brands:[] | any
  types:[] | any
  protected submitted = false;
  constructor(
    private readonly fb:FormBuilder,
    private productService:ProductService,
    private toastr:ToastrService
  ){
  
  }
  ngOnInit(): void {
    this.initializeForm()
    this.loadBrands()
    this.loadTypes()
  }
  onSubmit(){
    console.log(this.productForm.value)
    this.submitted = true
    if(!this.productForm.valid){
      this.toastr.warning("All the fields are required")
      return
    }
    this.addProduct()

  }
  protected get productFormControl(){
    return this.productForm.controls
  }
  public uploadProduct(args:any){
    if(args && args.target.files)
    {
      const reader = new FileReader();
      reader.readAsDataURL(args.target.files[0])
      reader.onloadend = (myEvent) => {
        if(myEvent.target?.result != null){
          this.PicturePreview = myEvent.target.result;
          this.pictureFile = (this.PicturePreview as string).split(',')[1]
        }
      }
    }
  }
  loadBrands(){
    this.productService.loadBrands().subscribe(data => this.brands = data)
  }
  loadTypes(){
    this.productService.loadTypes().subscribe(data => this.types = data)
  }
  private initializeForm():void{
    this.productForm = this.fb.group({
      ProductName :this.fb.control('',Validators.required),
      Description :this.fb.control('',[Validators.required,Validators.maxLength(1000)]),
      Price:this.fb.control('',Validators.required),
      ProductType:this.fb.control('',Validators.required),
      ProductBrand:this.fb.control('',Validators.required),
      ProductSpecs:this.fb.array([]),
      latest:this.fb.control(true)
    })
  }
  get ProductSpecs(): FormArray {
    return this.productForm.get('ProductSpecs') as FormArray;
  }
  addSpec():void{
    this.ProductSpecs.push(this.fb.control('',Validators.required))
  }
  removeSpec(index: number): void {
    this.ProductSpecs.removeAt(index);
  }
  private addProduct(){
    const productData:Product = {
      productName:this.productForm.controls['ProductName'].value,
      description:this.productForm.controls['Description'].value,
      productBrand:this.productForm.controls['ProductBrand'].value,
      productType:this.productForm.controls['ProductType'].value,
      productCode:this.productForm.controls['ProductName'].value,
      productSpecs:this.ProductSpecs.value.map((spec:any) => spec as string),
      pictureUrl:this.pictureFile,
      price:this.productForm.controls['Price'].value,
      latest:this.productForm.controls['latest'].value,  
    }
    this.productService.addProduct(productData).subscribe(
      {
        next:(res) => {
              this.toastr.success("Product added successfully")
            },
            error:(err) => {
              this.toastr.error("Failed to add product")
              console.log(err)
            }
      }
    )
  }
}
