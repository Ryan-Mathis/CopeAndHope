import { useEffect, useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarText,
  NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";

export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);

  // const toggleNavbar = () => setOpen(!open);

  // const getInventory = () => {
  //   //implement functionality here....
  //   getBikesInShopCount().then(setInventory);
  // };

  /*useEffect(() => {
    loggedInUser && getInventory();
  }, [loggedInUser]);*/

  return (
    <div>
      <Navbar color="light" light fixed="true" expand="lg">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
          <img
            src="./logo192.png"
            alt="logo"
            height={50}
            style={{ marginRight: "8px" }}
          />
          Cope and Hope
        </NavbarBrand>
        {loggedInUser ? (
          <>
            {/* <NavbarToggler onClick={toggleNavbar} />
            <Collapse isOpen={open} navbar>
              <Nav navbar>
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink tag={RRNavLink} to="/bikes">
                    Bikes
                  </NavLink>
                </NavItem>
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink tag={RRNavLink} to="/workorders">
                    Work Orders
                  </NavLink>
                </NavItem>
                {loggedInUser.roles.includes("Admin") && (
                  <NavItem onClick={() => setOpen(false)}>
                    <NavLink tag={RRNavLink} to="/employees">
                      Employees
                    </NavLink>
                  </NavItem>
                )}
              </Nav>
            </Collapse>
            <NavbarText style={{ marginRight: "4px" }}>
              Bikes in Garage:
            </NavbarText> */}
            <Button
              color="primary"
              onClick={(e) => {
                e.preventDefault();
                setOpen(false);
                logout().then(() => {
                  setLoggedInUser(null);
                  setOpen(false);
                });
              }}
            >
              Logout
            </Button>
          </>
        ) : (
          <Nav navbar>
            <NavItem>
              <NavLink tag={RRNavLink} to="/login">
                <Button color="primary">Login</Button>
              </NavLink>
            </NavItem>
          </Nav>
        )}
      </Navbar>
    </div>
  );
}
