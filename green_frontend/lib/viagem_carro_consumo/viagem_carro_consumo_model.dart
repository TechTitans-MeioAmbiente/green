import '/components/navbar_widget.dart';
import '/flutter_flow/flutter_flow_theme.dart';
import '/flutter_flow/flutter_flow_util.dart';
import '/flutter_flow/flutter_flow_widgets.dart';
import 'viagem_carro_consumo_widget.dart' show ViagemCarroConsumoWidget;
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class ViagemCarroConsumoModel
    extends FlutterFlowModel<ViagemCarroConsumoWidget> {
  ///  State fields for stateful widgets in this page.

  final unfocusNode = FocusNode();
  // State field(s) for TextField widget.
  FocusNode? textFieldFocusNode;
  TextEditingController? textController;
  String? Function(BuildContext, String?)? textControllerValidator;
  // Model for navbar component.
  late NavbarModel navbarModel1;
  // Model for navbar component.
  late NavbarModel navbarModel2;

  /// Initialization and disposal methods.

  void initState(BuildContext context) {
    navbarModel1 = createModel(context, () => NavbarModel());
    navbarModel2 = createModel(context, () => NavbarModel());
  }

  void dispose() {
    unfocusNode.dispose();
    textFieldFocusNode?.dispose();
    textController?.dispose();

    navbarModel1.dispose();
    navbarModel2.dispose();
  }

  /// Action blocks are added here.

  /// Additional helper methods are added here.
}
