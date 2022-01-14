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

  public customCommands: CustomCommand[];

  public newPrompt: string;
  public newResponse: string;

  constructor(private titleSvc: Title, private http: HttpClient, private customCommandSvc: CustomCommandsService) {
    this.titleSvc.setTitle('Command Editor');
  }

  ngOnInit(): void {
    this.loadCustomCommands();
  }

  addCommand(): void {
    const newCommand: CustomCommand = {
      commandPrompt: this.newPrompt,
      commandResponse: this.newResponse,
      editing: false
    }
    this.customCommandSvc.createCommand(newCommand).subscribe(
      () => {
        this.resetNewCommand();
        this.loadCustomCommands();
      },
      (err: any) => {
        throw err;
      })
  }

  deleteCommand(id: string): void {
    this.customCommandSvc.deleteCommand(id).subscribe(
      () => {
        this.loadCustomCommands();
      },
      (err: any) => {
        throw err;
      }
    )
  }

  saveEdit(command: CustomCommand): void {
    this.customCommandSvc.editCommand(command).subscribe(
      () => {
        this.loadCustomCommands();
      },
      (err: any) => {
        throw err;
      }
    )
  }

  toggleEditMode(command: CustomCommand): void {
    command.editing = !command.editing;
  }

  private loadCustomCommands(): void {
    this.customCommandSvc.getAllCustomCommands().subscribe(
      (res: CustomCommand[]) => {
        this.customCommands = res;
      },
      (err: any) => {
        throw err;
      }
    )
  }

  private resetNewCommand(): void {
    this.newPrompt = null;
    this.newResponse = null;
  }

}
