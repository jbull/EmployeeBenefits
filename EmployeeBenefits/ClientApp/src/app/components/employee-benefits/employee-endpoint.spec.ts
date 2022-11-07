/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EmployeeEndpoint } from './employee-endpoint';

describe('Service: EmployeeEndpoint', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EmployeeEndpoint]
    });
  });

  it('should ...', inject([EmployeeEndpoint], (service: EmployeeEndpoint) => {
    expect(service).toBeTruthy();
  }));
});
