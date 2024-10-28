import { Component, inject, Input, OnInit, TemplateRef } from '@angular/core';
import { GetTeacherOpinionsResponseModel, UserOpinionModel } from '../../models/user-opinion.model';
import { ActivatedRoute, Router } from '@angular/router';
import { UserOpinionService } from '../../services/user-opinion.service';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-get-teacher-opinions',
  templateUrl: './get-teacher-opinions.component.html',
  styleUrl: './get-teacher-opinions.component.scss'
})
export class GetTeacherOpinionsComponent implements OnInit{
  @Input() teacherId!: number; // teacherId
  @Input() totalOpinions: number = 0;
  opinions: UserOpinionModel[] = [];

  constructor(
    private userOpinionService: UserOpinionService,
    private router: Router,
    private route: ActivatedRoute
  ){}

  private modalService = inject(NgbModal);
	closeResult = '';

  open(content: TemplateRef<any>) {
    this.loadOpinionsOfTeacher(this.teacherId);
		this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then(
			(result) => {
				this.closeResult = `Closed with: ${result}`;
			},
			(reason) => {
				this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
			},
		);
	}
  
  public isShowAllDisabled(): boolean{
    return this.totalOpinions === 0;
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
  
  ngOnInit(): void {
    
  }

  private loadOpinionsOfTeacher(id: number): void {
    this.userOpinionService.getTeacherOpinions(id).subscribe((opinions: GetTeacherOpinionsResponseModel) => {
      this.opinions = [...opinions.userOpinions];
    });
  }
}
