import { Component } from '@angular/core';

@Component({
  selector: 'app-insights',
  templateUrl: './insights.component.html',
  styleUrls: ['./insights.component.css']
})
export class InsightsComponent {
  articles = [
    { title: 'Quelle carte choisir pour débuter en électronique ?', category: 'Guide débutant' },
    { title: 'Comparatif : Raspberry Pi 5 vs Arduino MEGA', category: 'Produits' },
    { title: 'Top 5 des projets DIY avec STM32', category: 'Projet pratique' },
    { title: 'Pourquoi RISC-V va révolutionner l’embarqué', category: 'Tech & Tendances' },
    { title: 'NeoBoard partenaire STMicroelectronics', category: 'Actualité' },
  ];
}
