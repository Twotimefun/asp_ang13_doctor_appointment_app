
import { User } from '../models/user.model';
import { TokenStorageService } from '../_services/token-storage.service';
import {Injectable} from "@angular/core";

@Injectable()
export class UserTokenConverter{
    constructor() { }

    AssignUserFromToken(token: TokenStorageService): User{
      var userToken = token.getUser();
      var user = new User ();
      user.FirstName = userToken.firstName;
      user.LastName = userToken.lastName;
      user.PhoneNumber = userToken.phoneNumber;
      user.Sex = userToken.sex;
      user.DateOfBirth = new Date(userToken.dateOfBirth);
      user.Email = userToken.email;
      return user;
    }
}

