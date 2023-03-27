import {Component, ElementRef, OnInit} from '@angular/core';
import {HomeHttpService} from "../../services/http/home-http.service";
import {first} from "rxjs";

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit{

  public testObj: any;
  public selectedResult = {
    id: 0,
    text: '',
    isCorrect: false,
  };
  public isShowSomeFun = false;
  constructor(private _homeHttp: HomeHttpService) {

  }
  ngOnInit() {
    this._homeHttp.getData().pipe(
      first()
    ).subscribe((data) => {
      this.testObj = data;
    } )
  }

  submit(elem: any) {
    const res1 = confirm('ARE YOU SURE????????');

    if (res1 && this.selectedResult.isCorrect) {
      const res2 = confirm('You have only one attempt for this smart test. Are you really sure?')
      if (res2) {
        elem.el.nativeElement.hidden = true;
        alert('That`s a right answer. You pass the test for GIGACHAD. You really brave, smart person. Congratulations!')
      } else {
        alert('Thanks for listening to me. I am rarely wrong, so I advise you to choose another answer')
      }
    } else if (!this.selectedResult.isCorrect) {
      alert(`We are all human and make mistakes. And you ${localStorage.getItem('surname')} are no exception. Therefore, I advise you to continue learning and be more diligent.`)
      this.isShowSomeFun = true;
      setTimeout(() => this.isShowSomeFun = false, 2000)
    }
    else {
      alert('You were close to a mistake, but I stopped you just in time. The main thing is to always think twice before making a decision.')
    }
  }

  chooseResult(data: any) {
    this.selectedResult = data.answer;
    this.selectedResult.id = data.id;
  }
}
