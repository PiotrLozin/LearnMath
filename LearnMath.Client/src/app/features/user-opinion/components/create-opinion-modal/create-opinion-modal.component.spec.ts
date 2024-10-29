import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOpinionModalComponent } from './create-opinion-modal.component';

describe('CreateOpinionModalComponent', () => {
  let component: CreateOpinionModalComponent;
  let fixture: ComponentFixture<CreateOpinionModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateOpinionModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateOpinionModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
