using System;
using Janno.Data.User.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace Janno.Data.User {

  public static class UserContextInitializer {

    public static void Initialize(UserContext context) {
      // region Roles
      if (!context.Roles.Any()) {
        Console.WriteLine("Creating Roles...");

        // Admin Role
        context.Roles.AddRange(
          new IdentityRole {
            Id = "b562e963-6e7e-4f41-8229-4390b1257hg6",
            Name = "Admin",
            NormalizedName = "ADMIN"
          });

        // Member Role
        context.Roles.AddRange(
          new IdentityRole {
            Id = "4390b1257hg6-6e7e-4f41-8229-b562e963",
            Name = "User",
            NormalizedName = "USER"
          }
        );

        context.SaveChanges();
        Console.WriteLine("Roles created!");
      }


      // User
      if (!context.User.Any()) {
        Console.WriteLine("Creating users...");

        // Admin
        var user = new User {
          Id = "2f2469d5-b35e-42d8-a90c-a6cc3b899b5a",
          UserName = "ludgart",
          NormalizedUserName = "LUDGART",
          Email = "faberlukas@hotmail.de",
          NormalizedEmail = "FABERLUKAS@HOTMAIL.DE",
          PasswordHash = "AQAAAAEAACcQAAAAEHdNYlyAgIUxfiPTnUynpTTtpqTL9LoTusV4qxhnX80/Zg9qV36WE9bvhSuzKigdGg==",
          SecurityStamp = "GV5NYDTJXX46BPUTOIHKRMSMF3X7Z25S",
          ConcurrencyStamp = "fe490719-2b07-432d-b7d5-f171f0dd941c",
          LockoutEnabled = true,

          Detail = new UserDetail {
            FirstName = "Lukas",
            Age = 22,
            Gender = UserGender.MALE,
          },

          UserLocation = new UserLocation {
            City = "Augsburg",
            Latitude = 48.3583779,
            Longitude = 10.7914009,
            Accuracy = 0
          },

          UserInterest = new UserInterest {
            Casino = false,
            Cinema = true,
            Movie = true,
            Music = true,
            Programming = true,
            VideoGame = true,
          },

          UserSport = new UserSport {
            Gym = true,
            MiniGolf = true,
            Bowling = false,
            Jog = true
          }
        };

        // User
        var user2 = new User {
          Id = "a6cc3b899b5a-b35e-42d8-a90c-2f2469d5",
          UserName = "testo",
          NormalizedUserName = "TESTO",
          Email = "faberlukas@hotmail.de",
          NormalizedEmail = "FABERLUKAS@HOTMAIL.DE",
          PasswordHash = "AQAAAAEAACcQAAAAEHdNYlyAgIUxfiPTnUynpTTtpqTL9LoTusV4qxhnX80/Zg9qV36WE9bvhSuzKigdGg==",
          SecurityStamp = "GV5NYDTJXX46BPUTOIHKRMSMF3X7Z25S",
          ConcurrencyStamp = "fe490719-2b07-432d-b7d5-f171f0dd941c",
          LockoutEnabled = true,

          Detail = new UserDetail {
            FirstName = "Christoph",
            Age = 22,
            Gender = UserGender.MALE,
          },

          UserLocation = new UserLocation {
            City = "München",
            Latitude = 48.1391871,
            Longitude = 11.5849897,
            Accuracy = 0
          },

          UserInterest = new UserInterest {
            Casino = true,
            Cinema = true,
            Movie = true,
            Music = true,
            Programming = false,
            VideoGame = true,
          },

          UserSport = new UserSport {
            Gym = true,
            MiniGolf = true,
            Bowling = false,
            Jog = true
          }
        };

        context.User.Add(user);
        context.User.Add(user2);

        context.SaveChanges();

        // Admin
        var userAdmin = new IdentityUserRole<string>() {
          RoleId = "b562e963-6e7e-4f41-8229-4390b1257hg6",
          UserId = user.Id
        };

        var userCustomer = new IdentityUserRole<string>() {
          RoleId = "4390b1257hg6-6e7e-4f41-8229-b562e963",
          UserId = user.Id
        };

        context.UserRoles.Add(userAdmin);
        context.UserRoles.Add(userCustomer);

        // User
        var user2Customer = new IdentityUserRole<string> {
          RoleId = "4390b1257hg6-6e7e-4f41-8229-b562e963",
          UserId = user2.Id
        };

        context.UserRoles.Add(user2Customer);


        // Save
        context.SaveChanges();

        Console.WriteLine("Users created!");
      }
    }

  }

}