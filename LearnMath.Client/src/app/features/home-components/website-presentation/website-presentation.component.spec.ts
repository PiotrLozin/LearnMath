import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WebsitePresentationComponent } from './website-presentation.component';

describe('WebsitePresentationComponent', () => {
  let component: WebsitePresentationComponent;
  let fixture: ComponentFixture<WebsitePresentationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WebsitePresentationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WebsitePresentationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
