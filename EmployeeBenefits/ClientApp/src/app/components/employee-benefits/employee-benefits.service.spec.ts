import { TestBed } from '@angular/core/testing';

import { EmployeeBenefitsService } from './employee-benefits.service';

describe('EmployeeBenefitsService', () => {
  let service: EmployeeBenefitsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeeBenefitsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
