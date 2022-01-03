import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { CustomCommandsService } from './custom-commands.service';

@Component({
  selector: 'custom-commands',
  templateUrl: './custom-commands.component.html',
  styleUrls: ['./custom-commands.component.css']
})
export class CustomCommandsComponent implements OnInit {

  public customCommands: CustomCommand[]

  constructor(private titleSvc: Title, private http: HttpClient, private customCommandSvc: CustomCommandsService) {
    this.titleSvc.setTitle('Command Editor');
  }

  ngOnInit(): void {
    this.customCommandSvc.getAllCustomCommands().subscribe(
      (res: CustomCommand[]) => {
        this.customCommands = res;
      },
      (err: any) => {
        throw err;
      }
    )
  }
}
