import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagePersonComponent } from './message-person.component';

describe('MessagePersonComponent', () => {
  let component: MessagePersonComponent;
  let fixture: ComponentFixture<MessagePersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MessagePersonComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MessagePersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
