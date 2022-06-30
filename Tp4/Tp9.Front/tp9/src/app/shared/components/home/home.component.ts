import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  images: any = [
    {img:"https://tse3.mm.bing.net/th?id=OIP.dFy1PVl9oppxDL9R0beviAAAAA&pid=Api",title:"Angular"},
    {img:"https://static.sitestack.cn/projects/TypeScript-4.0-zh/5ee6aac714faa7739f559fbea12b3114.jpeg",title:"TypeScript"},
    {img:"https://aalexeev239.github.io/rxjs-intro/pictures/rxjs-logo.png",title:"RxJS"},
    {img:"https://i0.wp.com/crossfit-kroftlaggl.at/wp-content/uploads/2016/03/bootstrap-logo.jpg?fit=300%2C300&ssl=1",title:"Bootstrap"},
    {img:"https://growiz.com.br/wp-content/uploads/2020/08/kisspng-c-programming-language-logo-microsoft-visual-stud-atlas-portfolio-5b899192d7c600.1628571115357423548838.png",title:"C#"},
    {img:"https://lh3.googleusercontent.com/Gs6kFTfe9wy0kp3RvMMhCEejwohHaVUEaY9mda3aweBM9S6BLjLo7Nu4uTNNDN9gPfk=w300",title:".NET Framework"}
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
