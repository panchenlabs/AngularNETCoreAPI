import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  template: ''
})
export class AbstractBaseComponent implements OnDestroy {

  public isDestroyed$ = new Subject<boolean>();

  ngOnDestroy(): void {
    this.isDestroyed$.next(true);
    this.isDestroyed$.complete();
  }

}
