import { Login } from "@/features/accounts/routes/Login";
import { Register } from "@/features/accounts/routes/Register";
import { Home } from "@/features/misc";
import { Create } from "@/features/sets";
import Details from "@/features/sets/routes/Details";
import { Library } from "@/features/sets/routes/Library";
import Practice from "@/features/sets/routes/Practice";
import AccountsLayout from "@/layouts/AccountsLayout";
import MainLayout from "@/layouts/MainLayout";
import { FC } from "react";
import { RouterProvider, createBrowserRouter } from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
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
    ],
  },
  {
    path: "/accounts",
    element: <AccountsLayout />,
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
]);

export const AppRouterProvider: FC = () => {
  return <RouterProvider router={router} />;
};
