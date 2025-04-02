import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomePessoasComponent } from './home-pessoas.component';

describe('HomePessoasComponent', () => {
  let component: HomePessoasComponent;
  let fixture: ComponentFixture<HomePessoasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomePessoasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomePessoasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
