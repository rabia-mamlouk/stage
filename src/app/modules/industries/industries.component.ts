import { Component } from '@angular/core';

@Component({
  selector: 'app-industries',
  templateUrl: './industries.component.html',
  styleUrls: ['./industries.component.css']
})
export class IndustriesComponent {
  industries = [
  { name: 'Aerospace', icon: '✈️' },
  { name: 'Automotive', icon: '🚗' },
  { name: 'Contract Manufacturing', icon: '🏭' },
  { name: 'Energy', icon: '⚡' },
  { name: 'Gaming', icon: '🎮' },
  { name: 'Healthcare', icon: '🏥' },
  { name: 'Personal Computing', icon: '💻' },
  { name: 'Consumer Electronics', icon: '📱' },
  { name: 'Industrial Automation', icon: '🤖' },
];


}
