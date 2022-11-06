/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EmployeeBenefitEndpointService } from './employee-benefit-endpoint.service';

describe('Service: EmployeeBenefitEndpoint', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EmployeeBenefitEndpointService]
    });
  });

  it('should ...', inject([EmployeeBenefitEndpointService], (service: EmployeeBenefitEndpointService) => {
    expect(service).toBeTruthy();
  }));
});
