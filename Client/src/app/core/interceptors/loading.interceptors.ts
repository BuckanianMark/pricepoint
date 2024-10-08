import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable} from "rxjs";
import { BusyService } from "../Services/busy.service";
import { Injectable } from "@angular/core";
import { delay, finalize } from "rxjs/operators";

@Injectable()
export class Loadinginterceptor implements HttpInterceptor{

    constructor(private busyService:BusyService){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(!req.url.includes('emailexists')){
            this.busyService.busy();
        }
        return next.handle(req).pipe(
            delay(500),
            finalize(() => {
                this.busyService.idle()
            })
        )
    }
    
}