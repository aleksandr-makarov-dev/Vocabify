import Anonymous from "@/features/accounts/components/Anonymous";
import Authorize from "@/features/accounts/components/Authorize";
import { Admin } from "@/features/accounts/routes/Admin";
import { Login } from "@/features/accounts/routes/Login";
import { Register } from "@/features/accounts/routes/Register";
import { Home } from "@/features/misc";
import { Create } from "@/features/sets/routes/Create";
import Details from "@/features/sets/routes/Details";
import { Library } from "@/features/sets/routes/Library";
import Practice from "@/features/sets/routes/Test";
import AccountsLayout from "@/layouts/AccountsLayout";
import MainLayout from "@/layouts/MainLayout";
import { FC } from "react";
import { RouterProvider, createBrowserRouter } from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Authorize />,
    children: [
      {
        element: <MainLayout />,
        children: [
          {
            index: true,
            element: <Home />,
          },
          {
            path: "library",
            element: <Library />,
          },
          {
            path: "create",
            element: <Create />,
          },
          {
            path: ":id",
            children: [
              {
                index: true,
                element: <Details />,
              },
              {
                path: "practice",
                element: <Practice />,
              },
            ],
          },
          {
            element: <Authorize />,
            children: [
              {
                path: "admin",
                element: <Admin />,
              },
            ],
          },
        ],
      },
    ],
  },
  {
    path: "/accounts",
    element: <AccountsLayout />,
    children: [
      {
        element: <Anonymous />,
        children: [
          {
            path: "register",
            element: <Register />,
          },
          {
            path: "login",
            element: <Login />,
          },
        ],
      },
    ],
  },
]);

export const AppRouterProvider: FC = () => {
  return <RouterProvider router={router} />;
};
