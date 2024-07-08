import { Component, Input, input } from '@angular/core';
import { FormBuilder, FormGroup, UntypedFormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'teacher-address',
  templateUrl: './address.component.html',
  styleUrl: './address.component.scss'
})
export class AddressComponent {

  constructor(
    private formBuilder: FormBuilder
  ){}

  @Input() addressForm: UntypedFormGroup = new FormGroup({});

  // addressForm = this.formBuilder.group({
  //   street: ['', Validators.compose([Validators.required])],
  //   city: ['', Validators.compose([Validators.required])],
  //   country: ['', Validators.compose([Validators.required])],
  //   postCode: ['', Validators.compose([Validators.required])]
  // })
}
