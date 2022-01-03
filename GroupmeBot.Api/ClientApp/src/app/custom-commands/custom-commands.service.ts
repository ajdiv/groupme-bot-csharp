import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class CustomCommandsService {

  constructor(private http: HttpClient) { }

  getAllCustomCommands(): Observable<CustomCommand[]> {
    return this.http.get<CustomCommand[]>('customcommands');
  }

}
