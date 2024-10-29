import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTeacherOpinionsComponent } from './get-teacher-opinions.component';

describe('GetTeacherOpinionsComponent', () => {
  let component: GetTeacherOpinionsComponent;
  let fixture: ComponentFixture<GetTeacherOpinionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetTeacherOpinionsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetTeacherOpinionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
