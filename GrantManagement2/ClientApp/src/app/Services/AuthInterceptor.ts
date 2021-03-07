import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>,
    next: HttpHandler): Observable<HttpEvent<any>> {

    const idToken = localStorage.getItem("id_token");
    console.log("registering the token id" +idToken)

    if (idToken !=null && idToken != undefined) {
      
      const cloned = req.clone({
        headers: req.headers.set("Authorization",
          "Bearer " + idToken)
      });
      console.log("cloned response"+cloned);
      return next.handle(cloned);
    }
    else {
      return next.handle(req);
    }
  }
}
