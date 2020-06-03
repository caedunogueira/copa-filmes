import { TestBed } from '@angular/core/testing';

import { CopamundoService } from './copamundo.service';

describe('CopamundoService', () => {
  let service: CopamundoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CopamundoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
