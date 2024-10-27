import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, inject, TemplateRef } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UserOpinionService } from '../../services/user-opinion.service';
import { UserOpinionPostRequestModel } from '../../models/user-opinion.model';
import { ModalDismissReasons, NgbDatepickerModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-create-opinion',
  templateUrl: './create-opinion.component.html',
  styleUrl: './create-opinion.component.scss'
})

export class CreateOpinionComponent {
  private modalService = inject(NgbModal);
	closeResult = '';

  open(content: TemplateRef<any>) {
		this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then(
			(result) => {
				this.closeResult = `Closed with: ${result}`;
			},
			(reason) => {
				this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
			},
		);
	}
  
  private getDismissReason(reason: any): string {
		switch (reason) {
			case ModalDismissReasons.ESC:
				return 'by pressing ESC';
			case ModalDismissReasons.BACKDROP_CLICK:
				return 'by clicking on a backdrop';
			default:
				return `with: ${reason}`;
		}
	}

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private userOpinionService: UserOpinionService
  ){}
  
  userOpinionForm = this.formBuilder.group({
    score: ['', Validators.required],
    description: ['', Validators.required],
    creatorId: ['', Validators.required],
    teacherId: ['', Validators.required]
  })

  onSubmit() {
    if (this.userOpinionForm.invalid)
      console.error('Form is invalid', this.userOpinionForm.value);

    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    let resource = this.mapToRequest(this.userOpinionForm.value);
    this.httpClient.post("http://localhost:5074/opinions", resource, { headers }).subscribe(
      res => {
        console.log('Server response', res);
      },
      err => {
        console.log('Error occurred', err);
      });;
    return 
  }

  mapToRequest(userOpinionForm: any): UserOpinionPostRequestModel {
    return {
      score: parseInt(userOpinionForm.score),
      description: userOpinionForm.description,
      creatorId: parseInt(userOpinionForm.creatorId),
      teacherId: parseInt(userOpinionForm.teacherId)
    }
  }
}
