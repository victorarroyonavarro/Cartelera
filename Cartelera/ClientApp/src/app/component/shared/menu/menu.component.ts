import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
})
export class MenuComponent {
  constructor(private router: Router) { }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;

  }
}
