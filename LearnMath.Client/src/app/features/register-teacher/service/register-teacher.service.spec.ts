import { TestBed } from '@angular/core/testing';

import { RegisterTeacherService } from './register-teacher.service';

describe('RegisterTeacherService', () => {
  let service: RegisterTeacherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegisterTeacherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
