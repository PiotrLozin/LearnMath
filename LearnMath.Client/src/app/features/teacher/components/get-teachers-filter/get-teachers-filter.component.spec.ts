import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTeachersFilterComponent } from './get-teachers-filter.component';

describe('GetTeachersFilterComponent', () => {
  let component: GetTeachersFilterComponent;
  let fixture: ComponentFixture<GetTeachersFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetTeachersFilterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetTeachersFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
