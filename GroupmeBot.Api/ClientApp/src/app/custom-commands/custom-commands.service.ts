import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class CustomCommandsService {

  constructor(private http: HttpClient) { }

  createCommand(newCommand: CustomCommand): Observable<void> {
    return this.http.post<void>('customcommands', newCommand);
  }

  deleteCommand(id: string): Observable<void> {
    return this.http.delete<void>('customcommands/' + id);
  }

  editCommand(command: CustomCommand): Observable<void> {
    return this.http.put<void>('customcommands/', command);
  }

  getAllCustomCommands(): Observable<CustomCommand[]> {
    return this.http.get<CustomCommand[]>('customcommands');
  }

}
