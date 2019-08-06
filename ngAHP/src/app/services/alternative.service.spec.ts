import { TestBed } from '@angular/core/testing';

import { AlternativeService } from './alternative.service';

describe('AlternativeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AlternativeService = TestBed.get(AlternativeService);
    expect(service).toBeTruthy();
  });
});
